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
	private IEnumerator Start()
	{
		startDialog01 = true;

		// ù ��° ��� �б� ����
		yield return new WaitUntil(() => dialog01.UpdateDialog1());
		

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

		// �� ��° ��� �б� ����
		yield return new WaitUntil(() => dialog02.UpdateDialog1());

		/*textCountdown.gameObject.SetActive(true);
		textCountdown.text = "The End";*/

		yield return new WaitForSeconds(2);

		//UnityEditor.EditorApplication.ExitPlaymode();
	}
}
