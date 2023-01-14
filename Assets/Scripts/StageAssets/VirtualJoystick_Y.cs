using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //��ġ�� ���õ� �������̽��� ������ ����
                                //���콺 Ŭ�� �������� ��  //���콺 �� ���� ��  //�巡�� ���� ��
public class VirtualJoystick_Y : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    //�� ��ũ��Ʈ�� ��׶��忡 ����� ����
    //��ġ�� ������ �κ��� ��׶����̱� ����

    //�����̴� ������ �����ϱ� ���ؼ� ������
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] public RectTransform rect_Joystick;

    //��׶����� �������� ������ �����ų ����
    private float radius;

    //ȭ�鿡�� ������ �÷��̾�
    [SerializeField] public GameObject go_Player;
    //������ �ӵ�
    [SerializeField] public float moveSpeed;

    //��ġ�� ���۵��� �� �����̰Ŷ�
    private bool isTouch = false;
    //������ ��ǥ
    public Vector3 movePosition;

    //private Animation anim;
    //ĳ���� ȸ������ ��������� value�� ���������� ������
    private Vector2 value;

    public float width = 0.5f;

    public GameObject ViewCamera = null;

    void Start()
    {
        //inspector�� �� rect Transform�� �����ϴ� �� ����
        //0.5�� ���ؼ� �������� ���ؼ� ���� �־���
        this.radius = rect_Background.rect.width * width;

        //this.anim = this.go_Player.GetComponent<Animation>();

    }

    //�̵� ����
    void Update()
    {
        RaycastHit m_Hit;
        if (this.isTouch)
        {
            this.go_Player.transform.position += this.movePosition;
            //���̽�ƽ �������� ĳ���� ȸ��
            if (this.value != null)
            {
                this.go_Player.transform.rotation = Quaternion.Euler(0f,
                Mathf.Atan2(this.value.x, this.value.y) * Mathf.Rad2Deg, 0f);
            }
        }

        Debug.DrawLine(go_Player.transform.position, ViewCamera.transform.position, Color.red);
        Vector3 direction = new Vector3(0, 7, -5);

        if (Physics.Linecast(go_Player.transform.position, ViewCamera.transform.position, out m_Hit))
        {
            ViewCamera.transform.position = m_Hit.point;
        }
        else
        {
            //cameraPosition = this.gameObject.transform.position;
            ViewCamera.transform.position = this.go_Player.transform.position + direction;
        }
    }



    //�������̽� ����

    //������ ��(��ġ�� ���۵��� ��)
    public void OnPointerDown(PointerEventData eventData)
    {
        this.isTouch = true;
    }

    //�� ���� ��
    public void OnPointerUp(PointerEventData eventData)
    {
        //�� ���� �� ����ġ�� ������
        rect_Joystick.localPosition = Vector3.zero;

        this.isTouch = false;
        //�����̴� ���� ������ �� �ٽ� Ŭ���ϸ� ���� ������ �Ǵ� ������ ��ħ
        this.movePosition = Vector3.zero;

        //this.anim.Play("idle@loop");
    }

    //�巡�� ������
    public void OnDrag(PointerEventData eventData)
    {
        //���콺 ������(x��, y�ุ �־ ����2)
        //���콺 ��ǥ���� ������ ��׶��� ��ǥ���� �� ����ŭ ���̽�ƽ(�� ���׶��)�� ������ ����
        this.value = eventData.position - (Vector2)rect_Background.position;

        //���α�
        //����2�� �ڱ��ڽ��� ����ŭ, �ִ� ��������ŭ ���Ѱ���
        value = Vector2.ClampMagnitude(value, radius);
        //(1,4)���� ������ (-3 ~ 5)���� ���α� ��

        //�θ�ü(��׶���) �������� ������ ������� ��ǥ���� �־���
        rect_Joystick.localPosition = value;

        //value�� ���Ⱚ�� ���ϱ�
        value = value.normalized;
        //x�࿡ ���⿡ �ӵ� �ð��� ���� ��
        //y�࿡ 0, ���� ���ҰŶ�
        //z�࿡ y���⿡ �ӵ� �ð��� ���� ��

        this.movePosition = new Vector3(value.x * moveSpeed * Time.deltaTime,
                                    0f,
                                    value.y * moveSpeed * Time.deltaTime);
    }
}
