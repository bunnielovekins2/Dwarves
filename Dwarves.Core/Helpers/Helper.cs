using CocosSharp;

namespace Dwarves.Core.Helpers
{
	public static class Helper
	{
		public static bool IsClickOnMe(this CCNode node, CCEventMouse ev)
		{
			return node.BoundingBoxTransformedToWorld.ContainsPoint(new CCPoint(ev.CursorX, ev.CursorY));
		}

		public static bool IsClickOnMe(this CCRect rect, CCEventMouse ev)
		{
			return rect.ContainsPoint(new CCPoint(ev.CursorX, ev.CursorY));
		}

		public static CCScene ToScene(this CCLayer layer, CCWindow window)
		{
			var scene = new CCScene(window);
			scene.AddChild(layer);
			return scene;
		}

		public static CCColor4B To4B(this CCColor3B colour)
		{
			return new CCColor4B(colour.R, colour.G, colour.B);
		}
	}
}
