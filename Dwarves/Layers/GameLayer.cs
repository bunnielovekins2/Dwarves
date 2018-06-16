using CocosSharp;
using Dwarves.Windows.UIControls;
using System.Linq;

namespace Dwarves.Windows.Layers
{
	public class GameLayer : CCLayer
	{
		private UIButton digBtn;
		private static AnnouncementArea announcementArea;

		public static void Announce(string text)
		{
			if (announcementArea != null)
			{
				announcementArea.Announce(text);
			}
		}

		public GameLayer()
		{
			digBtn = new UIButton(new CCSprite("UI/dig")) { UIPosition = UIPosition.Left1 };
			var btn2 = new UIButton(new CCSprite("UI/dig")) { UIPosition = UIPosition.Left2 };
			var btn3 = new UIButton(new CCSprite("UI/dig")) { UIPosition = UIPosition.Left3 };
			var btn4 = new UIButton(new CCSprite("UI/dig")) { UIPosition = UIPosition.Left4 };
			var btn5 = new UIButton(new CCSprite("UI/dig")) { UIPosition = UIPosition.Left5 };
			var btn6 = new UIButton(new CCSprite("UI/dig")) { UIPosition = UIPosition.Right1 };
			var btn7 = new UIButton(new CCSprite("UI/dig")) { UIPosition = UIPosition.Right2 };
			var btn8 = new UIButton(new CCSprite("UI/dig")) { UIPosition = UIPosition.Right3 };
			var btn9 = new UIButton(new CCSprite("UI/dig")) { UIPosition = UIPosition.Right4 };
			var btn10 = new UIButton(new CCSprite("UI/dig")) { UIPosition = UIPosition.Right5 };
			
			announcementArea = new AnnouncementArea();
			AddChild(announcementArea);

			AddChild(digBtn);
			foreach (var item in new[] { btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10 })
			{
				AddChild(item);
			}

			digBtn.OnClick += (ev) =>
			{
				GameLayer.Announce("Poo");
			};
		}

		protected override void AddedToScene()
		{
			base.AddedToScene();

			// Use the bounds to layout the positioning of our drawable assets
			CCRect bounds = VisibleBoundsWorldspace;

			// Position things
			foreach (UIButton child in Children.Where(x => x is UIButton).Select(x => x as UIButton))
			{
				child.PositionMeInTheUI(bounds);
			}

			announcementArea.PositionMe(bounds);

			// Click listener
		}
	}
}
