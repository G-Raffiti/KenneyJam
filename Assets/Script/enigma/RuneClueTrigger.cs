using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneClueTrigger: MonoBehaviour
{
	public RuneClueUI UiRunePanel;
	public ComicsPrompter comText;
	public List<runes> runes = new List<runes>();
	public string charater_reaction;

	private bool triggered = false;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player")) return;
		if (!triggered)
		{
			data.Instance.addRunes(runes);
			triggered = true;
			StartCoroutine(display_com());
		}
		UiRunePanel.show();
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