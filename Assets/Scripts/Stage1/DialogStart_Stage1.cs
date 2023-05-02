using System.Collections;
using UnityEngine;
using TMPro;


public class DialogStart_Stage1 : MonoBehaviour
{
    [SerializeField]
    private Dialog_Stage1 dialog01;


    [SerializeField]
    private Dialog_Stage1 dialog02;

	
	public bool startDialog01 = false, startDialog02 = false;

	public AudioSource audioSource;

	GameManager gameManager;
	Anubis_Anim Boss1Anim;
	BoomFX boomFX;
	public GameObject line;

    private void Awake()
    {
		gameManager = FindObjectOfType<GameManager>();
		Boss1Anim = FindObjectOfType<Anubis_Anim>();
		boomFX = FindObjectOfType<BoomFX>();

		
    }

    private IEnumerator Start()
	{
		startDialog01 = true;
		audioSource.Pause();
		gameManager.timeStop = true; Boss1Anim.timeStop = true; boomFX.timeStop = true;
		line.SetActive(false);


		// ù ��° ��� �б� ����
		yield return new WaitUntil(() => dialog01.UpdateDialog1());
		audioSource.Play();
		line.SetActive(true); gameManager.timeStop = false; boomFX.timeStop = false;
        Boss1Anim.timeStop = false;
		

		// ��� �б� ���̿� ���ϴ� �ൿ�� �߰��� �� �ִ�.

		// ĳ���͸� �����̰ų� �������� ȹ���ϴ� ����.. ����� 5-4-3-2-1 ī��Ʈ �ٿ� ����
		//textCountdown.gameObject.SetActive(true);
		int count = 69;
		while (count > 0)
		{
			//textCountdown.text = count.ToString();
			count--;
			/*if(count == 0)
            {
				startDialog02 = true;
            }*/

			yield return new WaitForSeconds(1);
		}
		//textCountdown.gameObject.SetActive(false);
		audioSource.Pause();
		line.SetActive(false); Boss1Anim.timeStop = true; gameManager.timeStop = true;
		boomFX.timeStop = true;
		// �� ��° ��� �б� ����
		yield return new WaitUntil(() => dialog02.UpdateDialog1());
		line.SetActive(true); Boss1Anim.timeStop = false; gameManager.timeStop = false; boomFX.timeStop = false;
		audioSource.Play();
		

		yield return new WaitForSeconds(2);

		//UnityEditor.EditorApplication.ExitPlaymode();
	}
}
