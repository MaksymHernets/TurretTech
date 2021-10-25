using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class TimerUI : MonoBehaviour
	{
		[SerializeField] Text text;

		private float _time;
		private Coroutine coroutine;

		public void StartTimer(int time = 0)
		{
			_time = time;
			coroutine = this.StartCoroutine(StartTime());
		}

		public void StopTimer()
		{
			StopCoroutine(coroutine);
		}

		public void ClearTimer()
		{
			_time = 0;
			StopCoroutine(coroutine);
		}

		private IEnumerator StartTime()
		{
			while ( true )
			{
				_time += Time.deltaTime;
				text.text = _time.ToString("0.00");
				yield return new WaitForEndOfFrame();
			}
			text.text = "0";
			yield return null;
		}
	}
}
