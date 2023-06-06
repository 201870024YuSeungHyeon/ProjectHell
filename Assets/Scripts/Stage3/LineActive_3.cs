using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineActive_3 : MonoBehaviour
{
    PlayerControl playerControl;
    public float time;
    public GameObject bind;
    public GameObject tiles;
    public GameObject BGM;
    public SpriteRenderer black;
    public bool on = false;
    public bool off = false;
    public bool fade = false;
    private void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
        bind.SetActive(false);
        BGM.SetActive(false);
        GameObject.Find("Line").transform.Find("Line1").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line2").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line3").gameObject.SetActive(false);
        GameObject.Find("Line").transform.Find("Line4").gameObject.SetActive(false);
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0)
        {
            GameObject.Find("Line").transform.Find("Line1").gameObject.SetActive(true);
        }
        if(time >= 4)
        {
            GameObject.Find("Line").transform.Find("Line2").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line3").gameObject.SetActive(true);
            GameObject.Find("Line").transform.Find("Line4").gameObject.SetActive(true);
        }
        if(time >= 38.5 && time < 48)
        {
            playerControl.flip = true;
            playerControl.jumpCC = true;
            bind.SetActive(true);
        }
        if(time >= 48.5)
        {
            playerControl.flip = false;
            playerControl.jumpCC = false;
            bind.SetActive(false);
        }
        if(time >= 60.5 && !on)
        {
            StartCoroutine(FadeInCoroutine());
            on = true;
        }
        if(time >= 68.5 && !off)
        {
            StartCoroutine(FadeOutCoroutine());
            off = true;
        }
        if(time >= 0.9f)
        {
            BGM.SetActive(true);
        }
    }

    IEnumerator FadeInCoroutine() //�г��� ���İ� ���� ( fadeIn ) 
    {
        yield return new WaitForSeconds(1f);
        float fadeCount = 0; //���İ�(����)
        while (fadeCount <= 1) //���İ� ���� �ּ�0 �ִ�1
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            black.color = new Color(255, 255, 255, fadeCount); //���̵��� �ݺ���
            if (fadeCount >= 0.9)
            {
                fade = true;
            }
        }
        
    }

    IEnumerator FadeOutCoroutine() //�г��� ���İ� ���� ( fadeIn ) 
    {
        yield return new WaitForSeconds(1f);
        float fadeCount = 0.9f; //���İ�(����)
        while (fadeCount > 0) //���İ� ���� �ּ�0 �ִ�1
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            black.color = new Color(255, 255, 255, fadeCount); //���̵��� �ݺ���
            if (fadeCount <= 0.1)
            {
                fade = false;
            }
        }
    }
}
