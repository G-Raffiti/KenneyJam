using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RuneButton: MonoBehaviour
{
	public runes rune;
	public Button btn;
	public BtnHub hub;
	public TextMeshProUGUI display;
	public TextMeshProUGUI value;

	public void Bind(BtnHub _hub, TextMeshProUGUI _display, TextMeshProUGUI _value)
	{
		hub = _hub;
		display = _display;
		value = _value;
		btn.onClick.AddListener(() => hub.ActiveRune(rune));
	}

	private void OnMouseEnter()
	{
		if (!data.Instance.runes.Contains(rune))
		{
			value.text = "????????????????";
			display.text = "????????????????";
		}
		else
		{
			display.text = BtnHub.ToStr(rune);
			value.text = hub.ToValue(rune);
		}
	}

	private void OnMouseExit()
	{
		value.text = "";
		display.text = "";
	}
	
	
}