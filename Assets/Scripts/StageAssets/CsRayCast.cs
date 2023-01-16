using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class CsRayCast : MonoBehaviour
{
	public Transform target;    // ��ä�ÿ� ���ԵǴ��� �Ǻ��� Ÿ��
	public float angleRange = 30f;
	public float radius = 5f;

	Color _blue = new Color(0f, 0f, 1f, 0.2f);
	Color _red = new Color(1f, 0f, 0f, 0.2f);

	bool isCollision = false;


	public GameObject monster;
	ChasePlayer chasePlayer;
	float time;

	// ray�� ����
	[SerializeField]
	private float _maxDistance = 1.5f;

	// ray�� ����
	[SerializeField]
	private Color _rayColor = Color.red;

	public GameObject button;
	VirtualJoystick_Y virtualJoystick;

	public int count;

	private void Start()
    {
        chasePlayer = monster.GetComponent<ChasePlayer>();
		virtualJoystick = button.GetComponent<VirtualJoystick_Y>();
    }

    // Update is called once per frame
    void Update()
	{
		Vector3 interV = target.position - transform.position;

		// target�� �� ������ �Ÿ��� radius ���� �۴ٸ�
		if (interV.magnitude <= radius)
		{
			// 'Ÿ��-�� ����'�� '�� ���� ����'�� ����
			float dot = Vector3.Dot(interV.normalized, transform.forward);
			// �� ���� ��� ���� �����̹Ƿ� ���� ����� cos�� ���� ���ؼ� theta�� ����
			float theta = Mathf.Acos(dot);
			// angleRange�� ���ϱ� ���� degree�� ��ȯ
			float degree = Mathf.Rad2Deg * theta;

			// �þ߰� �Ǻ�
			if (degree <= angleRange / 2f)
			{ 
				chasePlayer.goMonster = false;
				time = 0;
			}
            else
            {
				if (time >= 3f)
					chasePlayer.goMonster = true;
				time += Time.deltaTime;
			}
		}
		else
        {
			if (time >= 3f)
				chasePlayer.goMonster = true;
			time += Time.deltaTime;
		}	
	}
	private void OnDrawGizmos()
	{
		Handles.color = isCollision ? _red : _blue;
		// DrawSolidArc(������, ��ֺ���(��������), �׷��� ���� ����, ����, ������)
		Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, radius);
		Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, radius);


		Gizmos.color = _rayColor;

		// �Լ� �Ķ���� : Capsule�� ������, Capsule�� ����, Capsule�� ũ��(x, z �� ���� ū ���� ũ�Ⱑ ��), Ray�� ����, RaycastHit ���, Capsule�� ȸ����, CapsuleCast�� ������ �Ÿ�
		if (true == Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxDistance))
		{
			// Hit�� �������� ray�� �׷��ش�.
			Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
			virtualJoystick.moveSpeed = 0f;
		}
		else
		{
			// Hit�� ���� �ʾ����� �ִ� ���� �Ÿ��� ray�� �׷��ش�.
			Gizmos.DrawRay(transform.position, transform.forward * _maxDistance);
			virtualJoystick.moveSpeed = 7;
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
			count++;
			Debug.Log(count);
			Destroy(other.gameObject);
		}
    }
}