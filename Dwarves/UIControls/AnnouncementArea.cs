using CocosSharp;
using Dwarves.Core;

namespace Dwarves.Windows.UIControls
{
	public class AnnouncementArea : ClickableNode
	{
		private CCSprite leftSpr;
		private CCSprite rightSpr;
		private CCSprite midSpr;
		private CCLabel label;

		public AnnouncementArea()
		{
			leftSpr = new CCSprite("UI/announcementleft") { AnchorPoint = CCPoint.AnchorLowerLeft };
			rightSpr = new CCSprite("UI/announcementright") { AnchorPoint = CCPoint.AnchorLowerLeft };
			midSpr = new CCSprite("UI/announcementmiddle") { AnchorPoint = CCPoint.AnchorLowerLeft };

			AddChild(leftSpr);
			AddChild(rightSpr);
			AddChild(midSpr);

			label = new CCLabel("Hello", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
			AddChild(label);
			// events
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bounds">Bounds of the screen, not the ui</param>
		public void PositionMe(CCRect bounds)
		{
			PositionY = 0;
			PositionX = Globals.UIButtonSize;
			ContentSize = new CCSize(bounds.MaxX - Globals.UIButtonSize * 2, Globals.UIButtonSize / 2);

			rightSpr.PositionX = ContentSize.Width - Globals.UIButtonSize / 2;
			midSpr.PositionX = Globals.UIButtonSize / 2;
			var midWidth = ContentSize.Width - Globals.UIButtonSize;
			midSpr.ScaleX = midWidth / midSpr.ContentSize.Width;

			label.PositionX = Globals.UIButtonSize / 2;
		}

		public void Announce(string text)
		{
			label.Text = text;
		}
	}
}
