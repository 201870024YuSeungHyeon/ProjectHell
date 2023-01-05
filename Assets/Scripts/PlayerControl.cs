using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float jumpForce;
    
    public Vector3 player_Pos;
   
    private Rigidbody rb;
    
    GameObject jumpBtn, leftBtn, rightBtn;

    bool jumpAllowed = true;
    bool isJumping = false;

    private Vector3 MoveDir;

    PlayerHP playerhp;

    bool isHurt;
    private float fTickTime;
    private float fDestroyTime = 5f;

    AttackEvent attackEvent;
    public Material[] meshes;
    private MeshFilter meshFilter;
    public MeshRenderer ball;
    
    
    
   
   


    // Start is called before the first frame update
    void Start()
    {
        jumpBtn = GameObject.Find("JumpButton");
        leftBtn = GameObject.Find("LButton");
        rightBtn = GameObject.Find("RButton");

        
       
        rb = GetComponent<Rigidbody>();
        MoveDir = Vector3.zero;

        playerhp = FindObjectOfType<PlayerHP>();
        attackEvent = FindObjectOfType<AttackEvent>();
        meshFilter = GetComponent<MeshFilter>();
        ball = GetComponent<MeshRenderer>();
     
        


    }

    // Update is called once per frame
    void Update()
    {
        player_Pos = gameObject.transform.position;
        fTickTime += Time.deltaTime;

        if (jumpAllowed == false)
        {
            jumpBtn.GetComponent<Button>().interactable = true;
        }
        if (jumpAllowed == true)
        {
            jumpBtn.GetComponent<Button>().interactable = false;
        }

        /*if(playerhp.player_currentHP == 0)
        {
            //강림이 죽었을 때 내용 넣기
        }*/
        

        if (playerhp.player_currentHP != playerhp.player_MaxHP)
        {
            if(fTickTime >= fDestroyTime)
            {
                StartCoroutine(HurtCooldown());
                playerhp.IncreaseHP(1);
                fTickTime = 0f;
            }
        }
        if (attackEvent.bc == AttackEvent.ballColor.normal)
        {
            ball.materials[0];
        }
        if (attackEvent.bc == AttackEvent.ballColor.red)
        {
            meshFilter.sharedMesh = meshes[1];
           
        }
       
        if (attackEvent.bc == AttackEvent.ballColor.green)
        {
            meshFilter.sharedMesh = meshes[2];
        }
        if (attackEvent.bc == AttackEvent.ballColor.blue)
        {
            meshFilter.sharedMesh = meshes[3];
        }





    }

    public void JumpTouched()
    {
        if (!jumpAllowed)
        {
            jumpAllowed = true;
           
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
             
            gameObject.layer = 7;

        }
       
    }

    public void LButtonDown()
    {
        if(gameObject.transform.position.x > -0.89)
        {
            leftBtn.GetComponent<Button>().interactable = true;
            transform.Translate(-0.88f, 0.3f, 0);
        }       
    }
    public void RButtonDown()
    {
        if (gameObject.transform.position.x < 0.89)
        {
            rightBtn.GetComponent<Button>().interactable = true;
            transform.Translate(0.88f, 0.3f, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            gameObject.layer = 6;
            jumpAllowed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note_R") || other.CompareTag("Note_G") || other.CompareTag("Note_B") || other.CompareTag("Note_X"))
        {
            Hurt();
            fTickTime = 0f;
            StartCoroutine(HurtCooldown());
            Destroy(other.gameObject);
            Debug.Log(playerhp.player_currentHP);
        }
        else if (other.CompareTag("UnderFloor"))
        {
            Hurt();
            Debug.Log(playerhp.player_currentHP);
        }
       
    }

    public void Hurt()
    {
        if (!isHurt)
        {
            isHurt = true;
            playerhp.DecreaseHP(1);
            
        }
    }

    IEnumerator HurtCooldown()
    {
        yield return new WaitForSeconds(1f);
        isHurt = false;
    }

    
}
