using CocosSharp;
using Dwarves.Core.Helpers;
using System;

namespace Dwarves.Windows.UIControls
{
	public class UIButton : CCNode
	{
		private CCSprite _sprite;

		public UIButton(CCSprite sprite)
		{
			_sprite = sprite;
			sprite.AnchorPoint = CCPoint.AnchorUpperLeft;
			AddChild(sprite);

			var clickListener = new CCEventListenerMouse();
			clickListener.OnMouseUp = (ev) =>
			{
				if (sprite.IsClickOnMe(ev) && OnClick != null)
				{
					OnClick.Invoke(ev);
				}
			};
			AddEventListener(clickListener);
		}

		public CCPoint SpriteAnchorPoint
		{
			set
			{
				_sprite.AnchorPoint = value;
			}
		}

		public Action<CCEventMouse> OnClick;

		public UIPosition UIPosition { get; set; }

		public void PositionMeInTheUI(CCRect bounds)
		{
			if (UIPosition == UIPosition.None) return;
			Position = UIPosition.ToPoint(bounds);
		}
	}
}
