using UnityEngine;

public class Monster : MonoBehaviour
{
	[SerializeField] private GameObject _target;
	[SerializeField] private float _speed;
	[SerializeField] private Rigidbody _rigidbody;

	void Update()
    {
		_rigidbody.AddForceAtPosition(-transform.localPosition.normalized * _speed, _target.transform.localPosition); 
    }

	public void Died()
	{
		_rigidbody.isKinematic = true;
		_rigidbody.isKinematic = false;
		gameObject.SetActive(false);
	}	

	private void OnCollisionEnter(Collision collision)
	{
		if ( collision.gameObject.GetComponent<Entity>() != null )
		{
			collision.gameObject.GetComponent<Entity>().ToDamage();
			Died();
		}
	}
}
