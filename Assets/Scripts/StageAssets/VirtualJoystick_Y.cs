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
    [SerializeField] private RectTransform rect_Joystick;

    //��׶����� �������� ������ �����ų ����
    private float radius;

    //ȭ�鿡�� ������ �÷��̾�
    [SerializeField] private GameObject go_Player;
    //������ �ӵ�
    [SerializeField] private float moveSpeed;

    //��ġ�� ���۵��� �� �����̰Ŷ�
    private bool isTouch = false;
    //������ ��ǥ
    private Vector3 movePosition;

    //private Animation anim;
    //ĳ���� ȸ������ ��������� value�� ���������� ������
    private Vector2 value;

    void Start()
    {
        //inspector�� �� rect Transform�� �����ϴ� �� ����
        //0.5�� ���ؼ� �������� ���ؼ� ���� �־���
        this.radius = rect_Background.rect.width * 0.5f;

        //this.anim = this.go_Player.GetComponent<Animation>();

    }

    //�̵� ����
    void Update()
    {
        if (this.isTouch)
        {
            this.go_Player.transform.position += this.movePosition;
            //���̽�ƽ �������� ĳ���� ȸ��
            if (this.value != null)
            {
                this.go_Player.transform.rotation = Quaternion.Euler(0f,
                                                                     Mathf.Atan2(this.value.x, this.value.y) * Mathf.Rad2Deg,
                                                                     0f);
            }
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

        //this.anim.Play("run@loop");
    }
}
