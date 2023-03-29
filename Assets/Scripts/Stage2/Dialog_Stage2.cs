using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Stage2 : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers; //��ȭ�� �����ϴ� ĳ���͵��� UI �迭
    [SerializeField]
    private DialogData[] dialogs1; // ���� �б��� ��� ��� �迭
    [SerializeField]

    DialogStart_Stage2 dialogStart_Stage2;
    private bool isFirst2 = true; // ���� 1ȸ�� ȣ���ϱ� ���� ����
    private int currentDialogIndex2 = -1; // ���� ��� ����
    private int currentSpeakerIndex2 = 0; // ���� ���� �ϴ� ȭ��(Speaker)�� speakers �迭 ����
    private float typingSpeed2 = 0.1f;           // �ؽ�Ʈ Ÿ���� ȿ���� ��� �ӵ�
    private bool isTypingEffect2 = false;        // �ؽ�Ʈ Ÿ���� ȿ���� ���������

    // Update is called once per frame
    private void Awake()
    {
        if (dialogStart_Stage2.startDialog01 == true)
            UpdateDialog2();


    }

    private void DisableObjects()
    {
        // ��� ��ȭ ���� ���� ������Ʈ ��Ȱ��ȭ

        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            //ĳ���� �̹����� �� ���̰�
            speakers[i].spriteRenderer2.gameObject.SetActive(false);
        }
    }

    private void Setup2()
    {
        //��� ��ȭ ���� ���� ������Ʈ ��Ȱ��ȭ
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            //ĳ���� �̹��� ���̰�
            speakers[i].spriteRenderer2.gameObject.SetActive(true);
        }
    }
	public bool UpdateDialog2()
	{
		// ��� �бⰡ ���۵� �� 1ȸ�� ȣ��
		if (isFirst2 == true)
		{
			// �ʱ�ȭ. ĳ���� �̹����� Ȱ��ȭ�ϰ�, ��� ���� UI�� ��� ��Ȱ��ȭ
			Setup2();


			// �ڵ� ���(dialogStart_Stage2.startDialog=true)���� �����Ǿ� ������ ù ��° ��� ���
			if (dialogStart_Stage2.startDialog01 == true) SetNextDialog2();

			isFirst2 = false;
		}

		if (Input.GetKeyDown(KeyCode.Mouse0))//Input.touchCount > 0 ||
		{
			//Touch touch = Input.GetTouch(0);
			//if (touch.phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space))
			//{
			// �ؽ�Ʈ Ÿ���� ȿ���� ������϶� ��ġ�ϸ� Ÿ���� ȿ�� ����
			if (isTypingEffect2 == true)
			{
				isTypingEffect2 = false;

				// Ÿ���� ȿ���� �����ϰ�, ���� ��� ��ü�� ����Ѵ�
				StopCoroutine("OnTypingText");
				speakers[currentSpeakerIndex2].textDialog2.text = dialogs1[currentDialogIndex2].dialog;
				// ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
				speakers[currentSpeakerIndex2].objectArrow2.SetActive(true);

				return false;
			}

			// ��簡 �������� ��� ���� ��� ����
			if (dialogs1.Length > currentDialogIndex2 + 1)
			{
				SetNextDialog2();
			}
			// ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� true ��ȯ
			else
			{
				// ���� ��ȭ�� �����ߴ� ��� ĳ����, ��ȭ ���� UI�� ������ �ʰ� ��Ȱ��ȭ
				for (int i = 0; i < speakers.Length; ++i)
				{
					SetActiveObjects(speakers[i], false);
					// SetActiveObjects()�� ĳ���� �̹����� ������ �ʰ� �ϴ� �κ��� ���� ������ ������ ȣ��
					speakers[i].spriteRenderer2.gameObject.SetActive(false);
				}

				return true;
			}
			//}
		}

		return false;
	}
	private void SetNextDialog2()
	{
		// ���� ȭ���� ��ȭ ���� ������Ʈ ��Ȱ��ȭ
		SetActiveObjects(speakers[currentSpeakerIndex2], false);

		// ���� ��縦 �����ϵ��� 
		currentDialogIndex2++;

		// ���� ȭ�� ���� ����
		currentSpeakerIndex2 = dialogs1[currentDialogIndex2].speakerIndex;

		// ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
		SetActiveObjects(speakers[currentSpeakerIndex2], true);
		// ���� ȭ�� �̸� �ؽ�Ʈ ����
		speakers[currentSpeakerIndex2].textName2.text = dialogs1[currentDialogIndex2].name;
		// ���� ȭ���� ��� �ؽ�Ʈ ����
		//speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
		StartCoroutine("OnTypingText2");
	}
	private void SetActiveObjects(Speaker speaker, bool visible)
	{
		speaker.imageDialog2.gameObject.SetActive(visible);
		speaker.textName2.gameObject.SetActive(visible);
		speaker.textDialog2.gameObject.SetActive(visible);

		// ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ�ϱ� ������ �׻� false
		speaker.objectArrow2.SetActive(false);

		// ĳ���� ���� �� ����
		Color color = speaker.spriteRenderer2.color;
		color.a = visible == true ? 1 : 0.2f;
		speaker.spriteRenderer2.color = color;
	}
	private IEnumerator OnTypingText2()
	{
		int index = 0;

		isTypingEffect2 = true;

		// �ؽ�Ʈ�� �ѱ��ھ� Ÿ����ġ�� ���
		while (index < dialogs1[currentDialogIndex2].dialog.Length)
		{
			speakers[currentSpeakerIndex2].textDialog2.text = dialogs1[currentDialogIndex2].dialog.Substring(0, index);

			index++;

			yield return new WaitForSeconds(typingSpeed2);
		}

		isTypingEffect2 = false;

		// ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
		speakers[currentSpeakerIndex2].objectArrow2.SetActive(true);
	}
	[System.Serializable]
	public struct Speaker
	{
		public SpriteRenderer spriteRenderer2; // ĳ���� �̹���(���İ� ����)
		public Image imageDialog2; // ��ȭâ Image UI
		public TextMeshProUGUI textName2; // ���� ������� ĳ���� �̸���� Text UI
		public TextMeshProUGUI textDialog2; // ���� ��� ��� Text UI
		public GameObject objectArrow2; //��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� ������Ʈ
	}

	[System.Serializable]
	public struct DialogData1
	{
		public int speakerIndex2; // �̸��� ��縦 ����� ���� DialogSystem�� speakers �迭 ����
		public string name2; // ĳ���� �̸�
		[TextArea(3, 5)]
		public string dialog2; // ���
	}


}
