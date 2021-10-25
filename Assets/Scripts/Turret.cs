using UnityEngine;

public class Turret : Entity
{
    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _gun;
    [SerializeField] private float _rangeWatch = 1f;
    [SerializeField] private float _rotationSpeed = 0.1f;
    [SerializeField] private float _accuracy = 0.06f;
    
    private RaycastHit _hit;
    private GameObject _target;

    void Update()
    {
        if ( _target != null && _target.activeSelf == true)
        {
            if (TurnHead())
            {
                Shot();
            }
        }
        else
		{
            if (FindingTarget())
            {
                if (TurnHead()) { Shot(); }
            }

        }
    }

    private void Shot()
	{
        if (Physics.Raycast(_head.gameObject.transform.localPosition, _head.gameObject.transform.forward, out _hit))
        {
            if (_hit.transform.gameObject.tag == "Enemy")
            {
                _hit.transform.gameObject.SetActive(false);
            }
        }
    }

    private bool TurnHead()
	{
		Vector3 newDir = Vector3.RotateTowards(_head.transform.forward, (_target.transform.localPosition - _head.transform.localPosition), 0.5f, 0.0F);
		Quaternion _LookRotation = Quaternion.LookRotation(newDir);
		_head.transform.rotation = Quaternion.Slerp(_head.transform.localRotation, _LookRotation, Time.deltaTime * _rotationSpeed);

        return Vector3.Dot(_head.transform.localPosition.normalized, _target.transform.localPosition.normalized) < _accuracy;
	}

    private bool FindingTarget()
	{
        Collider[] colliders;
        if ((colliders = Physics.OverlapSphere(transform.position, _rangeWatch)).Length > 1)
        {
            for (int i = 0; i < colliders.Length; ++i)
            {
                if (colliders[i].tag == "Enemy")
                {
                    _target = colliders[i].gameObject;
                    return true;
                }
            }
        }
        return false;
    }
}


