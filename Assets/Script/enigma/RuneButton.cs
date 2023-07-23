using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RuneButton: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
	}

	public void ActivateRune()
	{
		Debug.Log("activate " + BtnHub.ToStr(rune));
		hub.ActiveRune(rune);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("mouse entered");
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

	public void OnPointerExit(PointerEventData eventData)
	{
		value.text = "";
		display.text = "";
	}
}