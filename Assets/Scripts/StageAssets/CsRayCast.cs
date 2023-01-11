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
	bool stopMonster;
    private void Start()
    {
        chasePlayer = monster.GetComponent<ChasePlayer>();
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
				if (time >= 5f)
					chasePlayer.goMonster = true;
				time += Time.deltaTime;
			}
		}
		else
        {
			if (time >= 5f)
				chasePlayer.goMonster = true;
			time += Time.deltaTime;
		}





		/*Debug.DrawRay(transform.position, transform.forward * 8, Color.red);

		//  ����ĳ��Ʈ�� �����ٷ� ������ ���� ����� �ش�.

		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, 8))
		// (������,���� ,hit info,�Ÿ�)
		{
			// ������ �浹�� ������Ʈ�� �α�â�� ���� �ش�.
			Debug.Log(hit.collider.gameObject.name);
			
			chasePlayer.goMonster = false;
			time = 0;
		}
		else
        {
			if(time >= 5f)
				chasePlayer.goMonster = true;
			time += Time.deltaTime;
		}*/


	}
	private void OnDrawGizmos()
	{
		Handles.color = isCollision ? _red : _blue;
		// DrawSolidArc(������, ��ֺ���(��������), �׷��� ���� ����, ����, ������)
		Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, radius);
		Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, radius);
	}
}