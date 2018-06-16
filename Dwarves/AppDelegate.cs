using CocosSharp;
using Dwarves.Windows.Layers;

namespace Dwarves.Windows
{
	public class AppDelegate : CCApplicationDelegate
	{

		public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
		{
			application.ContentRootDirectory = "Content";
			var windowSize = mainWindow.WindowSizeInPixels;

			var desiredWidth = 1024.0f;
			var desiredHeight = 768.0f;

			var bounds = mainWindow.WindowSizeInPixels;

			// This will set the world bounds to be (0,0, w, h)
			// CCSceneResolutionPolicy.ShowAll will ensure that the aspect ratio is preserved
			CCScene.SetDefaultDesignResolution(bounds.Width, bounds.Height, CCSceneResolutionPolicy.ShowAll);

			// Determine whether to use the high or low def versions of our images
			// Make sure the default texel to content size ratio is set correctly
			// Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
			if (desiredWidth < windowSize.Width)
			{
				application.ContentSearchPaths.Add("hd");
			}

			var scene = new CCScene(mainWindow);
			var introLayer = new IntroLayer();

			scene.AddChild(introLayer);

			mainWindow.RunWithScene(scene);
		}

		public override void ApplicationDidEnterBackground(CCApplication application)
		{
			application.Paused = true;
		}

		public override void ApplicationWillEnterForeground(CCApplication application)
		{
			application.Paused = false;
		}
	}
}