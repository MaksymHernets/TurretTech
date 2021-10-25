using Controller;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private ControllerHUD _controllerHud;
    [SerializeField] private ControllerEndGame _controllerEndGame;

	[SerializeField] private Turret _turret;

	private float _timeStartLevel;

	private void Start()
	{
		StartLevel();

		_turret.EventDie.AddListener(() =>
		{
			EndGame();
		}
		);
	}

	public void StartLevel()
	{
		_timeStartLevel = Time.realtimeSinceStartup;
		_turret.life = 3;
		_controllerHud.Init(new ModelHUD());
	}

	public void EndGame()
	{
		_controllerHud.Deactive();

		var model = new ModelEndGame();
		model.SceneManager = this;
		model.Score = Time.realtimeSinceStartup - _timeStartLevel;
		_controllerEndGame.Init(model);
	}
}
