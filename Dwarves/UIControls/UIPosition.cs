using CocosSharp;

namespace Dwarves.Windows.UIControls
{
	public static partial class WinHelpers
	{
		public static CCPoint ToPoint(this UIPosition pos, CCRect bounds)
		{
			float x, y;
			switch (pos)
			{
				case UIPosition.Left1:
					x = 0;
					y = bounds.MaxY;
					break;
				case UIPosition.Left2:
					x = 0;
					y = bounds.MaxY - Core.Globals.UIButtonSize;
					break;
				case UIPosition.Left3:
					x = 0;
					y = bounds.MaxY - Core.Globals.UIButtonSize * 2;
					break;
				case UIPosition.Left4:
					x = 0;
					y = bounds.MaxY - Core.Globals.UIButtonSize * 3;
					break;
				case UIPosition.Left5:
					x = 0;
					y = Core.Globals.UIButtonSize;
					break;
				case UIPosition.Right1:
					x = bounds.MaxX - Core.Globals.UIButtonSize;
					y = bounds.MaxY;
					break;
				case UIPosition.Right2:
					x = bounds.MaxX - Core.Globals.UIButtonSize;
					y = bounds.MaxY - Core.Globals.UIButtonSize;
					break;
				case UIPosition.Right3:
					x = bounds.MaxX - Core.Globals.UIButtonSize;
					y = bounds.MaxY - Core.Globals.UIButtonSize * 2;
					break;
				case UIPosition.Right4:
					x = bounds.MaxX - Core.Globals.UIButtonSize;
					y = bounds.MaxY - Core.Globals.UIButtonSize * 3;
					break;
				case UIPosition.Right5:
					x = bounds.MaxX - Core.Globals.UIButtonSize;
					y = Core.Globals.UIButtonSize;
					break;
				default:
					throw new System.Exception("Invalid UIPosition");
			}
			return new CCPoint(x, y);
		}
	}

	public enum UIPosition
	{
		None,
		Left1,
		Left2,
		Left3,
		Left4,
		Left5,
		Right1,
		Right2,
		Right3,
		Right4,
		Right5
	}
}
