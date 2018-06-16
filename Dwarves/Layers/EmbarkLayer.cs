using System;
using CocosSharp;
using Dwarves.Core.Helpers;
using Dwarves.Windows.UIControls;

namespace Dwarves.Windows.Layers
{
	public class EmbarkLayer : CCLayerColor
	{
		private CCLabel label;
		private CCDrawNode drawNode;
		private YesNoControl yesNo;
		private CCLabel mouseLabel;
		private UIButton startButton;

		public EmbarkLayer() : base(CCColor4B.Gray)
		{
			// Nodes
			label = new CCLabel("Option 1", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
			drawNode = new CCDrawNode();
			AddChild(label);
			AddChild(drawNode);

			mouseLabel = new CCLabel($"X: 0 Y: 0", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
			AddChild(mouseLabel);

			yesNo = new YesNoControl();
			drawNode.AddChild(yesNo);

			startButton = new UIButton(new CCSprite("UI/start")) { SpriteAnchorPoint = CCPoint.AnchorMiddle, Position = new CCPoint(VisibleBoundsWorldspace.MidX, 200) };
			startButton.OnClick = Start;
			AddChild(startButton);

			//Events
			var moveListener = new CCEventListenerMouse();
			moveListener.OnMouseMove = (ev) =>
			{
				mouseLabel.Text = $"X: {ev.CursorX} Y: {VisibleBoundsWorldspace.MaxY - ev.CursorY}";
				mouseLabel.Position = new CCPoint(ev.CursorX, VisibleBoundsWorldspace.MaxY - ev.CursorY);
			};
			AddEventListener(moveListener);
		}

		private void Start(CCEventMouse obj)
		{
			Core.Settings.Option1 = yesNo.State;
			Window.DefaultDirector.ReplaceScene(new GameLayer().ToScene(Window));
		}

		protected override void AddedToScene()
		{
			base.AddedToScene();

			var bounds = VisibleBoundsWorldspace;

			label.Position = new CCPoint(bounds.Center.X - 200, bounds.Center.Y);
			mouseLabel.Position = new CCPoint(0, 0);
			drawNode.Position = new CCPoint(0, 0);
			startButton.PositionX = bounds.MidX;

			yesNo.Init(new CCPoint(bounds.Center.X, bounds.Center.Y), drawNode);
		}
	}
}
