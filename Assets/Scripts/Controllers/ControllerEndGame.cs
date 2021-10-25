using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
	public class ControllerEndGame : MonoBehaviour, IController
	{
		[SerializeField] private Button _buttonPlayAgain;
		[SerializeField] private Text _textScore;

		private ModelEndGame _model;

		public void Init(IModel model)
		{
			_model = model as ModelEndGame;

			_buttonPlayAgain.onClick.AddListener(ButtonPlayAgain_Click);

			_textScore.text = _model.Score.ToString();

			gameObject.SetActive(true);
		}

		private void ButtonPlayAgain_Click()
		{
			Deactive();
		}

		public void Deactive()
		{
			this.gameObject.SetActive(false);
			_buttonPlayAgain.onClick.RemoveListener(ButtonPlayAgain_Click);

			_model.SceneManager.StartLevel();
		}
	}
}
