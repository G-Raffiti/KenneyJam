using System.Collections;
using TMPro;
using UnityEngine;

public class ComicsPrompter :MonoBehaviour
{
	public TextMeshProUGUI text;
	public void display(string _charater_reaction)
	{
		StartCoroutine(display_txt(_charater_reaction));
	}

	private IEnumerator display_txt(string _charater_reaction)
	{
		string txt = "";
		int letters = 1;
		while (letters <= _charater_reaction.Length)
		{
			txt = _charater_reaction.Substring(0, letters);
			text.text = txt;
			yield return new WaitForSeconds(0.02f);
			letters++;
		}
		yield return new WaitForSeconds(5f);
		gameObject.SetActive(false);
	}
}