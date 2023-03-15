using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anubis_Status : MonoBehaviour
{
    private int AnubisHP = 5;
    private float AnubisHPtime = 90;
    public Sprite img_AnubisHit, img_AnubisNormal,img_AnubisDead,img_AnubisLow;
    public SpriteRenderer thisImg;
    public AudioSource anubisHitSound, anubisDeadSound;
    
    void Start()
    {
        thisImg = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        AnubisHPtime -= Time.deltaTime;

        if(AnubisHP <= 0)
        {
            Debug.Log("�ƴ��� ����");
        }
        if(AnubisHPtime <= 0)
        {
            Debug.Log("�ƴ��� ����");
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            if(AnubisHP >= 4)
            {
                Destroy(other.gameObject);
                AnubisHP -= 1;
                StartCoroutine(BossHitImage());
                Debug.Log("�ƴ��� ü�� : " + AnubisHP);
                
                if (AnubisHP != 0)
                    anubisHitSound.Play();
                else
                    anubisDeadSound.Play();

            }
            else if(AnubisHP <= 3)
            {
                Destroy(other.gameObject);
                AnubisHP -= 1;
                StartCoroutine(BossHitImageLowHP());
                Debug.Log("�ƴ��� ü�� : " + AnubisHP);

                if (AnubisHP != 0)
                    anubisHitSound.Play();
                else
                    anubisDeadSound.Play();
            }
            if(AnubisHP == 0)
            {
                thisImg.sprite = img_AnubisDead;
                Destroy(other.gameObject);

                if (AnubisHP != 0)
                    anubisHitSound.Play();
                else
                    anubisDeadSound.Play();
            }
        }
    }

    IEnumerator BossHitImage()
    {
        thisImg.sprite = img_AnubisHit;
        yield return new WaitForSeconds(0.8f);
        thisImg.sprite = img_AnubisNormal;
    }

    IEnumerator BossHitImageLowHP()
    {
        thisImg.sprite = img_AnubisHit;
        yield return new WaitForSecondsRealtime(0.8f);
        thisImg.sprite = img_AnubisLow;
    }
}
