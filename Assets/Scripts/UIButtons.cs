using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public Image fadePanel;
    public void RetryButton_Stage1()
    {
        fadePanel.gameObject.SetActive(true); //�г� Ȱ��ȭ
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("GoStage1", 0.3f); //0.3f�� ����
      
    }

    public void RetryButton_Stage2()
    {
        fadePanel.gameObject.SetActive(true); //�г� Ȱ��ȭ
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("GoStage2", 0.3f); //0.3f�� ����

    }
    public void RetryButton_Stage3()
    {
        fadePanel.gameObject.SetActive(true); //�г� Ȱ��ȭ
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("GoStage3", 0.3f); //0.3f�� ����
       
    }

    public void StageButton()
    {
        fadePanel.gameObject.SetActive(true); //�г� Ȱ��ȭ
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("ChooseStage", 0.3f); //0.3f�� ����

    }

    public void GoMainButton()
    {
        fadePanel.gameObject.SetActive(true); //�г� Ȱ��ȭ
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("GoMain", 0.3f); //0.3f�� ����
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ChooseStage()
    {
        SceneManager.LoadScene("StageScene");
    }



    public void GoStage1() //�� ��ȯ
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void GoStage2()
    {
        SceneManager.LoadScene("Stage_2");
    }
    public void GoStage3()
    {
        SceneManager.LoadScene("Stage_3");
    }

    IEnumerator FadeOutCoroutine() //�г��� ���İ� ���� ( fadeOut )
    {
        float fadeCount = 0; //���İ�(����)
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            fadePanel.color = new Color(0, 0, 0, fadeCount);//���̵�ƿ� �ݺ���
        }
    }
}
