using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Stage3 : MonoBehaviour
{
	[SerializeField]
	private Speaker[] speakers; //��ȭ�� �����ϴ� ĳ���͵��� UI �迭

	public GameObject line;
	public AudioSource bgm;

	[SerializeField]
	private DialogData3[] dialogs3; // ���� �б��� ��� ��� �迭
	[SerializeField]

	DialogStart_Stage3 dialogStart_Stage3;
	private bool isFirst3 = true; // ���� 1ȸ�� ȣ���ϱ� ���� ����
	private int currentDialogIndex3 = -1; // ���� ��� ����
	private int currentSpeakerIndex3 = 0; // ���� ���� �ϴ� ȭ��(Speaker)�� speakers �迭 ����
	private float typingSpeed3 = 0.1f;           // �ؽ�Ʈ Ÿ���� ȿ���� ��� �ӵ�
	private bool isTypingEffect3 = false;       // �ؽ�Ʈ Ÿ���� ȿ���� ���������
	public bool isGameStarted = false;
	// Update is called once per frame
	private void Awake()
	{
		if (dialogStart_Stage3.startDialog01 == true)
		{
			UpdateDialog3();
		}
		//if (dialogStart_Stage2.startDialog02 == true && dialogStart_Stage2.startDialog01 == false)
		//UpdateDialog2();
	}

	private void Setup3()
	{
		//��� ��ȭ ���� ���� ������Ʈ ��Ȱ��ȭ
		for (int i = 0; i < speakers.Length; ++i)
		{
			SetActiveObjects(speakers[i], false);
			//ĳ���� �̹��� ���̰�
			speakers[i].spriteRenderer3.gameObject.SetActive(true);
		}
		//line.SetActive(false);
		//gameManager.Pause();
	}
	public bool UpdateDialog3()
	{
		// ��� �бⰡ ���۵� �� 1ȸ�� ȣ��
		if (isFirst3 == true)
		{
			// �ʱ�ȭ. ĳ���� �̹����� Ȱ��ȭ�ϰ�, ��� ���� UI�� ��� ��Ȱ��ȭ
			Setup3();

			// �ڵ� ���(dialogStart_Stage2.startDialog=true)���� �����Ǿ� ������ ù ��° ��� ���
			if (dialogStart_Stage3.startDialog01 == true) SetNextDialog3();

			isFirst3 = false;
		}

		/*if(dialogStart_Stage2.startDialog02 == true && dialogStart_Stage2.startDialog01 == false)
        {
			SetNextDialog2();
        }*/

		if (Input.GetKeyDown(KeyCode.Mouse0) && isGameStarted == false)//Input.touchCount > 0 ||
		{
			//Touch touch = Input.GetTouch(0);
			//if (touch.phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space))
			//{
			// �ؽ�Ʈ Ÿ���� ȿ���� ������϶� ��ġ�ϸ� Ÿ���� ȿ�� ����
			if (isTypingEffect3 == true)
			{
				isTypingEffect3 = false;

				// Ÿ���� ȿ���� �����ϰ�, ���� ��� ��ü�� ����Ѵ�
				StopCoroutine("OnTypingText3");
				speakers[currentSpeakerIndex3].textDialog3.text = dialogs3[currentDialogIndex3].dialog3;
				// ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
				speakers[currentSpeakerIndex3].objectArrow3.SetActive(true);

				return false;
			}

			// ��簡 �������� ��� ���� ��� ����
			if (dialogs3.Length > currentDialogIndex3 + 1)
			{
				SetNextDialog3();
			}
			// ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� true ��ȯ
			else
			{
				// ���� ��ȭ�� �����ߴ� ��� ĳ����, ��ȭ ���� UI�� ������ �ʰ� ��Ȱ��ȭ
				for (int i = 0; i < speakers.Length; ++i)
				{
					SetActiveObjects(speakers[i], false);
					// SetActiveObjects()�� ĳ���� �̹����� ������ �ʰ� �ϴ� �κ��� ���� ������ ������ ȣ��
					speakers[i].spriteRenderer3.gameObject.SetActive(false);
				}
				//line.SetActive(true);
				//bgm.Play();

				isGameStarted = true;
				/*
				if (isTypingEffect2 == true)
				{
					line.SetActive(false);
				}
				else if (isTypingEffect2 == false)
				{
					line.SetActive(true);
					isGameStarted = true;
				}*/
				return true;
			}
		}
		return false;
	}

	private void SetNextDialog3()
	{
		// ���� ȭ���� ��ȭ ���� ������Ʈ ��Ȱ��ȭ
		SetActiveObjects(speakers[currentSpeakerIndex3], false);

		// ���� ��縦 �����ϵ��� 
		currentDialogIndex3++;

		// ���� ȭ�� ���� ����
		currentSpeakerIndex3 = dialogs3[currentDialogIndex3].speakerIndex3;

		// ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
		SetActiveObjects(speakers[currentSpeakerIndex3], true);
		// ���� ȭ�� �̸� �ؽ�Ʈ ����
		speakers[currentSpeakerIndex3].textName3.text = dialogs3[currentDialogIndex3].name3;
		// ���� ȭ���� ��� �ؽ�Ʈ ����
		//speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
		StartCoroutine("OnTypingText3");
	}
	private void SetActiveObjects(Speaker speaker, bool visible)
	{
		speaker.imageDialog3.gameObject.SetActive(visible);
		speaker.textName3.gameObject.SetActive(visible);
		speaker.textDialog3.gameObject.SetActive(visible);

		// ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ�ϱ� ������ �׻� false
		speaker.objectArrow3.SetActive(false);

		// ĳ���� ���� �� ����
		Color color = speaker.spriteRenderer3.color;
		color.a = visible == true ? 1 : 0.2f;
		speaker.spriteRenderer3.color = color;
	}

	private IEnumerator OnTypingText3()
	{
		int index = 0;

		isTypingEffect3 = true;

		// �ؽ�Ʈ�� �ѱ��ھ� Ÿ����ġ�� ���
		while (index < dialogs3[currentDialogIndex3].dialog3.Length)
		{
			speakers[currentSpeakerIndex3].textDialog3.text = dialogs3[currentDialogIndex3].dialog3.Substring(0, index);

			index++;

			yield return new WaitForSeconds(typingSpeed3);
		}

		isTypingEffect3 = false;

		// ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
		speakers[currentSpeakerIndex3].objectArrow3.SetActive(true);
	}
	[System.Serializable]
	public struct Speaker
	{
		public SpriteRenderer spriteRenderer3; // ĳ���� �̹���(���İ� ����)
		public Image imageDialog3; // ��ȭâ Image UI
		public TextMeshProUGUI textName3; // ���� ������� ĳ���� �̸���� Text UI
		public TextMeshProUGUI textDialog3; // ���� ��� ��� Text UI
		public GameObject objectArrow3; //��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� ������Ʈ
	}

	[System.Serializable]
	public struct DialogData3
	{
		public int speakerIndex3; // �̸��� ��縦 ����� ���� DialogSystem�� speakers �迭 ����
		public string name3; // ĳ���� �̸�
		[TextArea(3, 5)]
		public string dialog3; // ���
	}
	[System.Serializable]
	public struct GameObejct
	{
		public GameObject tileNote;
		public GameObject noteBreak;
	}
}