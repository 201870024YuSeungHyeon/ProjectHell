using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public int player_MaxHP = 3;
    public int player_currentHP = 3;
    PlayerControl playerControl;


    // Start is called before the first frame update
    void Start()
    {
        
        playerControl = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player_currentHP == 0)
        {
            
            Debug.Log("���");
            ExitGame();
            //Invoke("GameOver", 1f); ���ӿ���ȭ��
        }


    }

    public void GameOver()
    {
        // SceneManager.LoadScene(���ӿ��� ��);
    }

    public void DecreaseHP(int p_num)
    {
        if(player_currentHP > 0)
        {
            player_currentHP -= p_num;
            //ShowHPImage();
        }
    }

    public void IncreaseHP(int p_num)
    {
        /*if (player_currentHP < player_MaxHP)
            player_currentHP += p_num;
        else
            player_currentHP = player_MaxHP; //�ִ�ü���� ���� �� ������
        //ShowHPImage();*/
    }

    void ShowHPImage()
    {
        //ü�� �̹��� ���� �ֱ�
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
