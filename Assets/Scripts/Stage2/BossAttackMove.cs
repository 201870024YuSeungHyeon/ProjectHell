using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttackMove : MonoBehaviour
{
    NavMeshAgent agent;
   GameObject player;
   AttackRandomSpawn atr;

   

    void Awake()
    {
        atr = FindObjectOfType<AttackRandomSpawn>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

       
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            atr.isAttackDestroyed = true;
        }
    }
}