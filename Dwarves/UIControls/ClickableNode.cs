using CocosSharp;
using Dwarves.Core.Helpers;

namespace Dwarves.Windows.UIControls
{
	public class ClickableNode : CCNode
	{
		public ClickableNode()
		{
			var clickListener = new CCEventListenerMouse();
			clickListener.OnMouseUp = (ev) =>
			{
				if (this.IsClickOnMe(ev) && OnClick != null)
				{
					OnClick.Invoke(ev);
				}
			};
			AddEventListener(clickListener);
		}

		public System.Action<CCEventMouse> OnClick;
	}
}
