using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TagChanger : MonoBehaviour
{
    public Material[] mat = new Material[4];
    public Sprite[] sprites = new Sprite[3];

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
        if (SceneManager.GetActiveScene().name == "Stage_3")
        {
            if (other.CompareTag("Note_R"))
            {
                other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[0];
            }
            if (other.CompareTag("Note_G"))
            {
                other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[1];
            }
            if (other.CompareTag("Note_B"))
            {
                other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[2];
            }
        }
    }
}
