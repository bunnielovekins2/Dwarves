using CocosSharp;

namespace Dwarves.Windows.UIControls
{
	public class YesNoControl : CCNode, DrawableNode
	{
		private CrapMenuButton buttonYes;
		private CrapMenuButton buttonNo;

		private bool _state;
		public bool State
		{
			get
			{
				return _state;
			}
			set
			{
				if (value)
				{
					buttonYes.ButtonActive = true;
					buttonNo.ButtonActive = false;
				}
				else
				{
					buttonNo.ButtonActive = true;
					buttonYes.ButtonActive = false;
				}
				_state = value;
			}
		}

		public YesNoControl()
		{
			buttonYes = new CrapMenuButton(CCColor3B.Green, "Yes");
			buttonNo = new CrapMenuButton(CCColor3B.Red, "No");

			AddChild(buttonYes);
			AddChild(buttonNo);

			buttonYes.OnClick += OnYesClick;
			buttonNo.OnClick += OnNoClick;
		}

		private void OnNoClick(CCEventMouse obj)
		{
			State = false;
		}

		private void OnYesClick(CCEventMouse obj)
		{
			State = true;
		}

		public void Init(CCPoint point, CCDrawNode drawNode)
		{
			buttonYes.Init(point, drawNode);
			buttonNo.Init(new CCPoint(point.X + 110, point.Y), drawNode);
		}

		public void Draw(CCDrawNode drawNode)
		{
			buttonYes.Draw(drawNode);
			buttonNo.Draw(drawNode);
		}


	}
}
