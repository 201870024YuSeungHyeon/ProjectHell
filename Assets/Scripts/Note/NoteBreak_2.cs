using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBreak_2 : MonoBehaviour
{
    public GameObject bgm;
    public float setTime = 0.5f;
    float time;
    void Start()
    {
        bgm.SetActive(false);
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= setTime)
        {
            bgm.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note_R") || other.CompareTag("Note_G") || other.CompareTag("Note_B") || other.CompareTag("Note_X") ||
            other.CompareTag("Note_AbsorbX") || other.CompareTag("SwordTrail") ||
            other.CompareTag("SwordTrail_Vertical") || other.CompareTag("Note_BB") || other.CompareTag("Note_BG") || other.CompareTag("Note_BR"))
        {
            Destroy(other.gameObject);
        }
    }
}
