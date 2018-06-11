using CocosSharp;
using Dwarves.Core.Helpers;

namespace Dwarves
{
	public class CrapMenuButton : CCNode
	{
		private readonly CCColor3B colour;
		private readonly string label;
		private CCLabel labelNode;
		private CCDrawNode drawNode;
		private bool clicked;
		private CCEventListenerMouse _eventListener;
		private int height;
		private int width;
		private CCRect rectangle;

		public CrapMenuButton(CCColor3B colour, string label)
		{
			this.colour = colour;
			this.label = label;
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

			AddChild(labelNode);
			ClickEventListener.OnMouseUp = (ccevent) =>
			{
				if (!rectangle.IsClickOnMe(ccevent)) return; // IsClickOnMe won't work for rectangle
				clicked = true;
				drawNode.Clear();
				foreach (var child in drawNode.Children)
				{
					if (child is CrapMenuButton menuButton)
					{
						menuButton.Draw(drawNode);
					}
				}
			};
		}

		public void Draw(CCDrawNode drawNode)
		{
			if (clicked)
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
				if (_eventListener == null)
				{
					_eventListener = new CCEventListenerMouse();
					AddEventListener(_eventListener);
				}
				return _eventListener;
			}
			set
			{
				_eventListener = value;
				AddEventListener(value);
			}
		}
	}
}
