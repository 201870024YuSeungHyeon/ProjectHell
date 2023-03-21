using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //public Image fadeOutPanel; //����ȭ�� ������Ʈ
    public GameObject Stage1_Panel;

    void Start()
    {
        Stage1_Panel.SetActive(false);
    }

    public void LoadingButton() //��ưŬ���� ȣ��
    {
        //fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel Ȱ��ȭ
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("LoadingSceneChange", 0.3f); //0.3f �� Change����
    }

    public void LoadingSceneChange() //�� ��ȯ �Լ�
    {
        SceneManager.LoadScene("LoadingScene"); //LodingScene������ ��ȯ
    }

    public void Stage_1Button() //��ưŬ���� ȣ��
    {
        //fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel Ȱ��ȭ
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("Stage_1SceneChange", 0.3f); //0.3f �� Change����
    }

    public void Stage_1SceneChange()
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void StageButton() //��ưŬ���� ȣ��
    {
        /*//fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel Ȱ��ȭ
        StartCoroutine("FadeOutCoroutine"); //�ڷ�ƾ �Լ� ȣ��
        Invoke("StageChange", 0.3f); //0.3f �� Change����*/
        Stage1_Panel.SetActive(true);
    }

    public void StageChange() //�� ��ȯ �Լ�
    {
        SceneManager.LoadScene("StageScene"); //LodingScene������ ��ȯ
    }

    public void ExitButton()
    {
        ExitGame();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    IEnumerator FadeOutCoroutine()//�г��� ���İ� ���� ( fadeOut )
    {
        float fadeCount = 0; //���İ�(����)
        while (fadeCount < 1.0f)//���İ� ���� �ּ�0 �ִ�1
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            //fadeOutPanel.color = new Color(0, 0, 0, fadeCount);//���̵�ƿ� �ݺ���
        }
    }
}
