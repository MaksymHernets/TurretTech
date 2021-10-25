using UI;
using UnityEngine;

namespace Controller
{
	public class ControllerHUD : MonoBehaviour, IController
	{
		[SerializeField] private TimerUI _timerUI;
		[SerializeField] private Monster _prefabMonster;

		private PoolObjects<Monster> _poolMonsters;
		private RaycastHit _hit;
		private Ray _ray;

		public void Init(IModel model)
		{
			gameObject.SetActive(true);

			_poolMonsters = new PoolObjects<Monster>(_prefabMonster);

			_timerUI.StartTimer();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(_ray, out _hit))
				{
					if (_hit.transform.name == "PlaneGround")
					{
						var monster = _poolMonsters.Get();
						monster.gameObject.SetActive(true);
						monster.gameObject.transform.localPosition = _hit.point + new Vector3(0, 0.3f, 0);
					}
				}
			}
		}

		public void Deactive()
		{
			gameObject.SetActive(false);
		}
	}
}

