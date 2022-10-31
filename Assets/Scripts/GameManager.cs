using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    MeshRenderer sr;
    private float time;
    private float fadeCount = 0; //���İ�(����)

    GameObject Tile2, Tile4, Fog;

    // Start is called before the first frame update
    void Start()
    {
        Tile2 = GameObject.Find("Tile2");
        Tile4 = GameObject.Find("Tile4");
        Fog = GameObject.Find("Fog");
        sr = Fog.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Stage_1")
        {
            time += Time.deltaTime;
            if(time >= 125)
            {
                Tile2.SetActive(false);
                Tile4.SetActive(false);
            }
            if(time >= 69 && fadeCount == 0)
            {
                StartCoroutine("FogCoroutine"); //�ڷ�ƾ �Լ� ȣ��
            }
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
}
