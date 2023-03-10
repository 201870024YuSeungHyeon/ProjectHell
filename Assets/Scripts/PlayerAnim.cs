using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnim : MonoBehaviour
{
    public Animator atkAnim;
    AttackEvent attackEvent;


    // Start is called before the first frame update
    void Start()
    {
        attackEvent = FindObjectOfType<AttackEvent>();
        atkAnim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
