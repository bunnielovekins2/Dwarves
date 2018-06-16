using CocosSharp;
using Dwarves.Core.Helpers;
using System;

namespace Dwarves.Windows.UIControls
{
	public class CrapMenuButton : CCNode, DrawableNode
	{
		private readonly CCColor3B colour;
		private readonly string label;
		private CCLabel labelNode;
		public bool ButtonActive;
		private CCEventListenerMouse _eventListener;
		private int height;
		private int width;
		private CCRect rectangle;

		public CrapMenuButton(CCColor3B colour, string label)
		{
			this.colour = colour;
			this.label = label;
			ClickEventListener = new CCEventListenerMouse();
		}

		public void Init(CCPoint point, CCDrawNode drawNode)
		{
			height = 50;
			var midheight = height / 2;
			width = 100;
			var midwidth = width / 2;
			rectangle = new CCRect(point.X - midwidth, point.Y - midheight, width, height);

			drawNode.DrawRect(rectangle, colour.To4B());

			labelNode = new CCLabel(label, "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont)
			{
				Position = point
			};

			AddChild(labelNode, 3);
			ClickEventListener.OnMouseUp = (ccevent) =>
			{
				if (!rectangle.IsClickOnMe(ccevent)) return;
				ButtonActive = true;
				if (OnClick != null)
				{
					OnClick.Invoke(ccevent);
				}
				drawNode.RedrawMe();
			};
		}

		public void Draw(CCDrawNode drawNode)
		{
			if (ButtonActive)
			{
				drawNode.DrawRect(rectangle, colour.To4B(), 1, CCColor4B.White);
			}
			else
			{
				drawNode.DrawRect(rectangle, colour.To4B());
			}
		}
		
		public CCEventListenerMouse ClickEventListener
		{
			get
			{
				return _eventListener;
			}
			set
			{
				_eventListener = value;
				AddEventListener(value);
			}
		}

		public Action<CCEventMouse> OnClick;
	}
}
