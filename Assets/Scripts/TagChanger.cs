using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChanger : MonoBehaviour
{
    public Material[] mat = new Material[4];

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("fjgkldf");
        if (other.CompareTag("Note_CR"))
        {
            other.gameObject.tag = "Note_B";
            other.gameObject.GetComponent<MeshRenderer>().material = mat[2];
        }
        if (other.CompareTag("Note_CG"))
        {
            other.gameObject.tag = "Note_R";
            other.gameObject.GetComponent<MeshRenderer>().material = mat[0];
        }
        if (other.CompareTag("Note_CB"))
        {
            Debug.Log("�۵�");
            other.gameObject.tag = "Note_G";
            other.gameObject.GetComponent<MeshRenderer>().material = mat[1];
        }
        if (other.CompareTag("Note_X"))
        {
            other.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            other.gameObject.GetComponent<MeshRenderer>().material = mat[3];
        }
    }
}
