using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineActive : MonoBehaviour
{
    private float time;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 12)
        {
            GameObject.Find("Line").transform.Find("Line1").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line2").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line3").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line4").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line5").gameObject.SetActive(true);
        }
    }
}