using System.Collections;
using System.Linq;
using UnityEngine;

public class RuneClueTrigger: MonoBehaviour
{
	public RuneClueUI UiRunePanel;
	public ComicsPrompter comText;
	public runes[] runes = new runes[3];
	public string charater_reaction;

	private bool triggered = false;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player")) return;
		if (!triggered)
		{
			data.Instance.addRunes(runes.ToList());
			triggered = true;
			StartCoroutine(display_com());
		}
		UiRunePanel.show(runes[0], runes[1], runes[2]);
	}

	private IEnumerator display_com()
	{
		yield return new WaitForSeconds(2);
		comText.gameObject.SetActive(true);
		comText.display(charater_reaction);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (!other.CompareTag("Player")) return;
		UiRunePanel.hide();
	}
}