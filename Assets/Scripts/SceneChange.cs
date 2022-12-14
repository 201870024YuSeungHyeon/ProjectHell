using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //public Image fadeOutPanel; //검은화면 컴포넌트

    public void LoadingButton() //버튼클릭시 호출
    {
        //fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("LoadingSceneChange", 0.3f); //0.3f 후 Change실행
    }

    public void LoadingSceneChange() //씬 전환 함수
    {
        SceneManager.LoadScene("LoadingScene"); //LodingScene씬으로 전환
    }

    public void Stage_1Button() //버튼클릭시 호출
    {
        //fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("Stage_1SceneChange", 0.3f); //0.3f 후 Change실행
    }

    public void Stage_1SceneChange()
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void StageButton() //버튼클릭시 호출
    {
        //fadeOutPanel.gameObject.SetActive(true); //fadeOutPanel 활성화
        StartCoroutine("FadeOutCoroutine"); //코루틴 함수 호출
        Invoke("StageChange", 0.3f); //0.3f 후 Change실행
    }

    public void StageChange() //씬 전환 함수
    {
        SceneManager.LoadScene("StageScene"); //LodingScene씬으로 전환
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

    IEnumerator FadeOutCoroutine()//패널의 알파값 조절 ( fadeOut )
    {
        float fadeCount = 0; //알파값(투명도)
        while (fadeCount < 1.0f)//알파값 변경 최소0 최대1
        {
            fadeCount += 0.10f;
            yield return new WaitForSeconds(0.01f);
            //fadeOutPanel.color = new Color(0, 0, 0, fadeCount);//페이드아웃 반복문
        }
    }
}
