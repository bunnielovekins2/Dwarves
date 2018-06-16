using CocosSharp;
using Dwarves.Windows.UIControls;

namespace Dwarves.Windows
{
	public static partial class WinHelpers
	{
		public static void RedrawMe(this CCDrawNode node)
		{
			node.Clear();
			void draw(CCNode childNode)
			{
				if (childNode is DrawableNode)
				{
					(childNode as DrawableNode).Draw(node);
				}
				foreach (var childItem in childNode.Children)
				{
					draw(childItem);
				}
			}
			foreach (var child in node.Children)
			{
				draw(child);
			}
		}
	}
}
