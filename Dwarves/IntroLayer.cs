using CocosSharp;
using Dwarves.Core.Helpers;

namespace Dwarves.Windows
{
	public class IntroLayer : CCLayerColor
	{

		// Define a label variable
		CCLabel label;

		public IntroLayer() : base(CCColor4B.Blue)
		{
			// create and initialize a Label
			label = new CCLabel("Start game", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);

			// add the label as a child to this Layer
			AddChild(label);
		}

		private void OnMouseUp(CCEventMouse obj)
		{
			if (label.IsClickOnMe(obj))
			{
				Window.DefaultDirector.ReplaceScene(new EmbarkLayer().ToScene(Window));
			}
		}

		protected override void AddedToScene()
		{
			base.AddedToScene();

			// Use the bounds to layout the positioning of our drawable assets
			var bounds = VisibleBoundsWorldspace;

			// position the label on the center of the screen
			label.Position = bounds.Center;

			var listener = new CCEventListenerMouse();
			listener.OnMouseUp = OnMouseUp;
			label.AddEventListener(listener);
			//AddEventListener(listener, label);
		}
	}
}

