using CocosSharp;

namespace Dwarves.Windows.UIControls
{
	public interface DrawableNode
	{
		void Init(CCPoint point, CCDrawNode drawNode);
		void Draw(CCDrawNode drawNode);
	}
}
