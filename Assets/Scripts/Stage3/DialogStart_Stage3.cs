using System.Collections;
using UnityEngine;
using TMPro;


public class DialogStart_Stage3 : MonoBehaviour
{
	[SerializeField]
	private Dialog_Stage3 dialog01;


	[SerializeField]
	private Dialog_Stage3 dialog02;


	public bool startDialog01 = false, startDialog02 = false;

	public AudioSource audioSource;

	Reaper_Anim Boss3Anim;
	Boss3_Status statusB3;
	
	public GameObject line;

	private void Awake()
	{	
		Boss3Anim = FindObjectOfType<Reaper_Anim>();
		statusB3 = FindObjectOfType<Boss3_Status>();
	}

	private IEnumerator Start()
	{
		startDialog01 = true;
		audioSource.Pause();
	    Boss3Anim.timeStop = true;
		statusB3.timeStop = true;
		line.SetActive(false);


		// ù ��° ��� �б� ����
		yield return new WaitUntil(() => dialog01.UpdateDialog3());
		audioSource.Play();
		line.SetActive(true);  Boss3Anim.timeStop = false; statusB3.timeStop = false;


		// ��� �б� ���̿� ���ϴ� �ൿ�� �߰��� �� �ִ�.

		// ĳ���͸� �����̰ų� �������� ȹ���ϴ� ����.. ����� 5-4-3-2-1 ī��Ʈ �ٿ� ����
		//textCountdown.gameObject.SetActive(true);
		int count = 36;
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
		line.SetActive(false); Boss3Anim.timeStop = true; statusB3.timeStop = true;
        // �� ��° ��� �б� ����
        yield return new WaitUntil(() => dialog02.UpdateDialog3());
		line.SetActive(true); Boss3Anim.timeStop = false; statusB3.timeStop = false;
        audioSource.Play();


		yield return new WaitForSeconds(2);

		//UnityEditor.EditorApplication.ExitPlaymode();
	}
}
