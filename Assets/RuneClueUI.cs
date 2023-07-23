using System;
using UnityEngine;

public class RuneClueUI : MonoBehaviour
{
	public RectTransform rect;
	private float target_pos = 200f;
	private int sign = 1;
	
	public void show()
	{
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
		if (Mathf.Abs(rect.anchoredPosition.y - target_pos) > 1)
		{
			rect.anchoredPosition += new Vector2(0, sign * Time.deltaTime);
		}
	}
}
