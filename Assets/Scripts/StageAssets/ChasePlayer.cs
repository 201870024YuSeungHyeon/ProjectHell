using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChasePlayer : MonoBehaviour
{
    public Transform playerPos;

    public float monsterSpeed = 0.05f;
    public Image ghost;
    public bool goMonster;
    int countDie;
    public float time;
    public bool touch;

    UnityEngine.AI.NavMeshAgent agent;

    private void Start()
    {
        goMonster = true;
        touch = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (goMonster == true && touch == false)
        {
            //transform.localPosition = Vector3.MoveTowards(transform.localPosition, playerPos.localPosition, monsterSpeed);
            agent.destination = playerPos.localPosition;
        }
        else if (goMonster == false)
        {
            agent.destination = this.gameObject.transform.localPosition;
        }
        else if (touch == true)
        {
            agent.destination = this.gameObject.transform.localPosition;
            time += Time.deltaTime;
        }

        if (time >= 3f)
            touch = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("��ġ");
            this.touch = true;
            countDie++;
            playerPos.transform.position = new Vector3(36, 1, 0);
            ghost.gameObject.SetActive(true);
            ghost.color = new Color(255, 255, 255, 255);      
            time = 0;
            StartCoroutine(FadeInCoroutine());
        }          
    }

    IEnumerator FadeInCoroutine() //�г��� ���İ� ���� ( fadeIn ) 
    {
        yield return new WaitForSeconds(1f);
        float fadeCount = 1; //���İ�(����)
        while (fadeCount > 0.0f) //���İ� ���� �ּ�0 �ִ�1
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            ghost.color = new Color(255, 255, 255, fadeCount); //���̵��� �ݺ���
        }
        ghost.gameObject.SetActive(false);
    }
}
