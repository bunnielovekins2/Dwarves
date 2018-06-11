using CocosSharp;

namespace Dwarves
{
	public class EmbarkLayer : CCLayerColor
	{
		private CCLabel label;
		private CrapMenuButton yesButton;
		private CrapMenuButton noButton;
		private CCDrawNode drawNode;

		public EmbarkLayer() : base(CCColor4B.Gray)
		{
			label = new CCLabel("Option 1", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
			yesButton = new CrapMenuButton(CCColor3B.Green, "Yes");
			noButton = new CrapMenuButton(CCColor3B.Red, "No");
			drawNode = new CCDrawNode();
			AddChild(label);
			AddChild(drawNode);
			drawNode.AddChild(yesButton);
			drawNode.AddChild(noButton);
		}

		protected override void AddedToScene()
		{
			base.AddedToScene();

			var bounds = VisibleBoundsWorldspace;
			
			label.Position = new CCPoint(bounds.Center.X - 200, bounds.Center.Y);
			drawNode.Position = new CCPoint(0, 0);
			
			yesButton.Init(new CCPoint(bounds.Center.X, bounds.Center.Y), drawNode);
			noButton.Init(new CCPoint(bounds.Center.X + 100, bounds.Center.Y), drawNode);
		}
	}
}
