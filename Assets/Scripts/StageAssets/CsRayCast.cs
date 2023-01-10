using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CsRayCast : MonoBehaviour
{
	ChasePlayer chasePlayer;
    private void Start()
    {
        chasePlayer = GetComponent<ChasePlayer>();
    }

    // Update is called once per frame
    void Update()
	{
		Debug.DrawRay(transform.position, transform.forward * 8, Color.red);

		//  ����ĳ��Ʈ�� �����ٷ� ������ ���� ����� �ش�.

		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, 8))
		// (������,���� ,hit info,�Ÿ�)
		{
			Debug.Log(hit.collider.gameObject.name);
			// ������ �浹�� ������Ʈ�� �α�â�� ���� �ش�.
			chasePlayer.goMonster = false;
		}
		else chasePlayer.goMonster = true;

	}
}