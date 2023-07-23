using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RuneClueUI : MonoBehaviour
{
	public RectTransform rect;
	private float target_pos = 200f;
	private int sign = 1;
	
	public Image[] icon_rune_A = new Image[2];
	public TextMeshProUGUI description_A;
	public Image[] icon_rune_B = new Image[2];
	public TextMeshProUGUI description_B;
	public Image[] icon_rune_C = new Image[2];
	public TextMeshProUGUI description_C;
	
	public void show(runes runeA, runes runeB, runes runeC)
	{
		description_A.text = BtnHub.ToStr(runeA);
		icon_rune_A[0].sprite = data.Instance.runes_imgs[runeA];
		icon_rune_A[1].sprite = data.Instance.runes_imgs[runeA];
		
		description_B.text = BtnHub.ToStr(runeB);
		icon_rune_B[0].sprite = data.Instance.runes_imgs[runeB];
		icon_rune_B[1].sprite = data.Instance.runes_imgs[runeB];
		
		description_C.text = BtnHub.ToStr(runeC);
		icon_rune_C[0].sprite = data.Instance.runes_imgs[runeC];
		icon_rune_C[1].sprite = data.Instance.runes_imgs[runeC];
		
		target_pos = -200;
		sign = -1;
	}

	public void hide()
	{
		target_pos = 200;
		sign = 1;
	}

	private void Update()
	{
		float speed = Mathf.Abs(rect.anchoredPosition.y - target_pos);
		if (speed > 1)
		{
			rect.anchoredPosition += new Vector2(0, sign * speed * Time.deltaTime);
		}
	}
}
