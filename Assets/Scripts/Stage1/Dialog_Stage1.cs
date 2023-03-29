using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Stage1 : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers; //��ȭ�� �����ϴ� ĳ���͵��� UI �迭
    [SerializeField]
    private DialogData[] dialogs1; // ���� �б��� ��� ��� �迭
	[SerializeField]

	DialogStart_Stage1 dialogStart_Stage1;
    private bool isFirst1 = true; // ���� 1ȸ�� ȣ���ϱ� ���� ����
    private int currentDialogIndex1 = -1; // ���� ��� ����
    private int currentSpeakerIndex1 = 0; // ���� ���� �ϴ� ȭ��(Speaker)�� speakers �迭 ����
    private float typingSpeed1 = 0.1f;           // �ؽ�Ʈ Ÿ���� ȿ���� ��� �ӵ�
    private bool isTypingEffect1 = false;        // �ؽ�Ʈ Ÿ���� ȿ���� ���������

    // Update is called once per frame
    private void Awake()
    {
		if (dialogStart_Stage1.startDialog01==true)
			UpdateDialog1();
		

	}
    /*private void Update()
    {
		if (dialogStart_Stage1.startDialog02 == true)
			UpdateDialog1();
	}*/

    private void DisableObjects()
    {
		// ��� ��ȭ ���� ���� ������Ʈ ��Ȱ��ȭ

		for (int i = 0; i < speakers.Length; ++i)
		{
			SetActiveObjects(speakers[i], false);
			//ĳ���� �̹����� �� ���̰�
			speakers[i].spriteRenderer1.gameObject.SetActive(false);
		}
	}

    private void Setup1()
    {
        //��� ��ȭ ���� ���� ������Ʈ ��Ȱ��ȭ
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            //ĳ���� �̹��� ���̰�
            speakers[i].spriteRenderer1.gameObject.SetActive(true);
        }
    }

	public bool UpdateDialog1()
	{
		// ��� �бⰡ ���۵� �� 1ȸ�� ȣ��
		if (isFirst1 == true)
		{
			// �ʱ�ȭ. ĳ���� �̹����� Ȱ��ȭ�ϰ�, ��� ���� UI�� ��� ��Ȱ��ȭ
			Setup1();
			

			// �ڵ� ���(dialogStart_Stage1.startDialog=true)���� �����Ǿ� ������ ù ��° ��� ���
			if (dialogStart_Stage1.startDialog01==true) SetNextDialog1();

			isFirst1 = false;
		}

		if (Input.GetKeyDown(KeyCode.Mouse0))//Input.touchCount > 0 ||
		{
			//Touch touch = Input.GetTouch(0);
			//if (touch.phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space))
			//{
				// �ؽ�Ʈ Ÿ���� ȿ���� ������϶� ��ġ�ϸ� Ÿ���� ȿ�� ����
				if (isTypingEffect1 == true)
				{
					isTypingEffect1 = false;

					// Ÿ���� ȿ���� �����ϰ�, ���� ��� ��ü�� ����Ѵ�
					StopCoroutine("OnTypingText");
					speakers[currentSpeakerIndex1].textDialog1.text = dialogs1[currentDialogIndex1].dialog;
					// ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
					speakers[currentSpeakerIndex1].objectArrow1.SetActive(true);

					return false;
				}

				// ��簡 �������� ��� ���� ��� ����
				if (dialogs1.Length > currentDialogIndex1 + 1)
				{
					SetNextDialog1();
				}
				// ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� true ��ȯ
				else
				{
					// ���� ��ȭ�� �����ߴ� ��� ĳ����, ��ȭ ���� UI�� ������ �ʰ� ��Ȱ��ȭ
					for (int i = 0; i < speakers.Length; ++i)
					{
						SetActiveObjects(speakers[i], false);
						// SetActiveObjects()�� ĳ���� �̹����� ������ �ʰ� �ϴ� �κ��� ���� ������ ������ ȣ��
						speakers[i].spriteRenderer1.gameObject.SetActive(false);
					}

					return true;
				}
			//}
		}

		return false;
	}

	private void SetNextDialog1()
	{
		// ���� ȭ���� ��ȭ ���� ������Ʈ ��Ȱ��ȭ
		SetActiveObjects(speakers[currentSpeakerIndex1], false);

		// ���� ��縦 �����ϵ��� 
		currentDialogIndex1++;

		// ���� ȭ�� ���� ����
		currentSpeakerIndex1 = dialogs1[currentDialogIndex1].speakerIndex;

		// ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
		SetActiveObjects(speakers[currentSpeakerIndex1], true);
		// ���� ȭ�� �̸� �ؽ�Ʈ ����
		speakers[currentSpeakerIndex1].textName1.text = dialogs1[currentDialogIndex1].name;
		// ���� ȭ���� ��� �ؽ�Ʈ ����
		//speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
		StartCoroutine("OnTypingText1");
	}

	private void SetActiveObjects(Speaker speaker, bool visible)
	{
		speaker.imageDialog1.gameObject.SetActive(visible);
		speaker.textName1.gameObject.SetActive(visible);
		speaker.textDialog1.gameObject.SetActive(visible);

		// ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ�ϱ� ������ �׻� false
		speaker.objectArrow1.SetActive(false);

		// ĳ���� ���� �� ����
		Color color = speaker.spriteRenderer1.color;
		color.a = visible == true ? 1 : 0.2f;
		speaker.spriteRenderer1.color = color;
	}

	private IEnumerator OnTypingText1()
	{
		int index = 0;

		isTypingEffect1 = true;

		// �ؽ�Ʈ�� �ѱ��ھ� Ÿ����ġ�� ���
		while (index < dialogs1[currentDialogIndex1].dialog.Length)
		{
			speakers[currentSpeakerIndex1].textDialog1.text = dialogs1[currentDialogIndex1].dialog.Substring(0, index);

			index++;

			yield return new WaitForSeconds(typingSpeed1);
		}

		isTypingEffect1 = false;

		// ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
		speakers[currentSpeakerIndex1].objectArrow1.SetActive(true);
	}

	[System.Serializable]
	public struct Speaker
	{
		public SpriteRenderer spriteRenderer1; // ĳ���� �̹���(���İ� ����)
		public Image imageDialog1; // ��ȭâ Image UI
		public TextMeshProUGUI textName1; // ���� ������� ĳ���� �̸���� Text UI
		public TextMeshProUGUI textDialog1; // ���� ��� ��� Text UI
		public GameObject objectArrow1; //��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� ������Ʈ
	}

	[System.Serializable]
	public struct DialogData1
	{
		public int speakerIndex1; // �̸��� ��縦 ����� ���� DialogSystem�� speakers �迭 ����
		public string name1; // ĳ���� �̸�
		[TextArea(3, 5)]
		public string dialog1; // ���
	}




}
