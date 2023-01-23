using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    float rightMax; //�·� �̵������� (x)�ִ밪
    float leftMax; //��� �̵������� (x)�ִ밪
    float currentPosition; //���� ��ġ(x) ����
    float direction = 3.0f; //�̵��ӵ�+����
    float cRight;
    float cLeft;
    float time;
    public bool stop = false;
    Vector3 position;

    void Start()
    {
        position = this.gameObject.transform.position;
        currentPosition = this.gameObject.transform.position.x;
        cRight = Random.Range(0.1f, 3);
        cLeft = Random.Range(0.1f, 3) * -1;
        rightMax = cRight + this.gameObject.transform.position.z;
        leftMax = cLeft + this.gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 4)
            stop = true;
        if (!stop)
        {
            currentPosition += Time.deltaTime * direction;
            if (currentPosition >= rightMax)
            {
                direction *= -1;
                currentPosition = rightMax;
            }
            //���� ��ġ(x)�� ��� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�
            //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� ��� �̵������� (x)�ִ밪���� ����
            else if (currentPosition <= leftMax)
            {
                direction *= -1;
                currentPosition = leftMax;
            }

            //���� ��ġ(x)�� �·� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�
            //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� �·� �̵������� (x)�ִ밪���� ����
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 1, currentPosition);
            //"Stone"�� ��ġ�� ���� ������ġ�� ó��
        }
        else if (stop == true)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, position, 0.01f);
        }
    }
}
