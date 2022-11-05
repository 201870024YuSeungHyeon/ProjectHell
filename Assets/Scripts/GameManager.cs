using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    MeshRenderer sr, tr2, tr4;
    private float time;
    private float xTime = 0, blinktime = 0.1f, waittime = 0.2f;
    private float fadeCount = 0; //알파값(투명도)

    GameObject Tile2, Tile4, Fog;

    CameraShake cameraShake;

    bool on = false;
    

    // Start is called before the first frame update
    void Start()
    {
        Tile2 = GameObject.Find("Tile2");
        Tile4 = GameObject.Find("Tile4");
        Fog = GameObject.Find("Fog");
        sr = Fog.GetComponent<MeshRenderer>();
        tr2 = Tile2.GetComponent<MeshRenderer>();
        tr4 = Tile4.GetComponent<MeshRenderer>();
        cameraShake = FindObjectOfType<CameraShake>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Stage_1")
        {
            time += Time.deltaTime;
            if(time < 7f)
            {
                tr2.material.color = new Color(255, 0, 255, 1);
                tr4.material.color = new Color(255, 0, 255, 1);
            }
            else
            {
                if(xTime < blinktime)
                {
                    tr2.material.color = new Color(255, 0, 255, 1 - xTime * 10 + 0.3f);
                    tr4.material.color = new Color(255, 0, 255, 1 - xTime * 10 + 0.3f);
                }
                else if(xTime < waittime + blinktime)
                {

                }
                else
                {
                    tr2.material.color = new Color(255, 0, 255, (xTime - (waittime + blinktime)) * 10 + 0.3f);
                    tr4.material.color = new Color(255, 0, 255, (xTime - (waittime + blinktime)) * 10 + 0.3f);
                    if(xTime > waittime + blinktime * 2)
                    {
                        xTime = 0;
                        waittime *= 0.8f;
                        if(waittime < 0.02f)
                        {
                            time = 0f;
                            waittime = 0.2f;
                        }
                    }
                }
                xTime += Time.deltaTime;
            }
            
            if(time >= 10)
            {
                if (!on)
                {
                    cameraShake.Shake();
                    on = true;
                }
                Tile2.SetActive(false);
                Tile4.SetActive(false);
            }
            if(time >= 69 && fadeCount == 0)
            {
                StartCoroutine("FogCoroutine"); //코루틴 함수 호출
            }
        }
    }
    IEnumerator FogCoroutine()//패널의 알파값 조절 ( fadeOut )
    {
        while (fadeCount < 1.0f) //알파값 최소0 최대1
        {
            fadeCount += 0.03f;
            yield return new WaitForSeconds(0.01f);
            sr.material.color = new Color(255, 0, 0, fadeCount);//페이드아웃 반복문
        }
    }

    IEnumerator TileCoroutine()
    {
        while (fadeCount > 0.0f) //알파값 최소0 최대1
        {
            fadeCount -= 0.03f;
            yield return new WaitForSeconds(0.01f);
            tr2.material.color = new Color(255, 0, 255, fadeCount);//페이드아웃 반복문
            tr4.material.color = new Color(255, 255, 0, fadeCount);//페이드아웃 반복문
        }
    }
}
