using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StageButton : MonoBehaviour
{

    public Image fadePanel; //����ȭ�� ������Ʈ
    public GameObject gameStartButton; //���ӽ��۹�ư ������Ʈ
                                     
    public void Button() //��ư Ŭ���� ȣ��
    {
        fadePanel.gameObject.SetActive(true); //�г� Ȱ��ȭ
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("choiceMap", 0.3f); 
    }


    public void choiceMap()
    {
        SceneManager.LoadScene("StageScene"); //StageScene���� ��ȯ
    }
    IEnumerator FadeOutCoroutine() //�г��� ���İ� ���� ( fadeOut )
    {
        float fadeCount = 0; //���İ�(����)
        while (fadeCount < 1.0f) //���İ� ���� �ּ�0 �ִ�1
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, fadeCount); //���̵�ƿ� �ݺ���
        }
    }
}
