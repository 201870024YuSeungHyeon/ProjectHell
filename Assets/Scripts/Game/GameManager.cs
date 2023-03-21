using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations;

public class GameManager : MonoBehaviour
{
    MeshRenderer sr, tr2, tr4;
    public float time;
    private float xTime = 0, blinktime = 0.1f, waittime = 0.2f;
    private float fadeCount = 0; //���İ�(����)

    GameObject Tile2, Tile4, Fog;

    CameraShake cameraShake;
    PauseButton pauseButton;

    public GameObject optionPanel;

    bool on = false;
    bool IsPause;
    

    // Start is called before the first frame update
    void Start()
    {
        Tile2 = GameObject.Find("Tile2");
        Tile4 = GameObject.Find("Tile4");
        Fog = GameObject.Find("Fog");
        //sr = Fog.GetComponent<MeshRenderer>();
        tr2 = Tile2.GetComponent<MeshRenderer>();
        tr4 = Tile4.GetComponent<MeshRenderer>();
        cameraShake = FindObjectOfType<CameraShake>();
        pauseButton = FindObjectOfType<PauseButton>();

        optionPanel = GameObject.Find("OptionPanel");
        optionPanel.gameObject.SetActive(false);

        IsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Stage_1")
        {
            time += Time.deltaTime;

            if(time >= 70) //Default : time >= 70
            {                           
                if (!on)
                {
                    cameraShake.Shake();
                    on = true;
                }
                Tile2.SetActive(false);
                Tile4.SetActive(false);
            }
            /*if(time >= 69 && fadeCount == 0)
            {
                StartCoroutine("FogCoroutine"); //�ڷ�ƾ �Լ� ȣ��
            }*/
        }
    }

    public void Pause()
    {
        if (IsPause == false)
        {
            Time.timeScale = 0;
            IsPause = true;
            return;
        }
        if (IsPause == true)
        {
            Time.timeScale = 1;
            IsPause = false;
            return;
        }
    }
    IEnumerator FogCoroutine()//�г��� ���İ� ���� ( fadeOut )
    {
        while (fadeCount < 1.0f) //���İ� �ּ�0 �ִ�1
        {
            fadeCount += 0.03f;
            yield return new WaitForSeconds(0.01f);
            sr.material.color = new Color(255, 0, 0, fadeCount);//���̵�ƿ� �ݺ���
        }
    }

    IEnumerator TileCoroutine()
    {
        while (fadeCount > 0.0f) //���İ� �ּ�0 �ִ�1
        {
            fadeCount -= 0.03f;
            yield return new WaitForSeconds(0.01f);
            tr2.material.color = new Color(255, 0, 255, fadeCount);//���̵�ƿ� �ݺ���
            tr4.material.color = new Color(255, 255, 0, fadeCount);//���̵�ƿ� �ݺ���
        }
    }
}
