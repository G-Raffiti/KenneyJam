﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum runes
{
	sound_plus,
	sound_minus,
	speed_plus,
	speed_minus,
	radar_switch,
	zoom_plus,
	zoom_minus,
	start_rune_code,
	validate_rune_code,
	rotation_speed_plus,
	rotation_speed_minus,
	activate_planetes,
}

public class BtnHub:MonoBehaviour
{
	[Header("rune btn")]
	public TextMeshProUGUI display;
	public TextMeshProUGUI value;
	public List<Sprite> icons;
	public List<RuneButton> btns;

	private bool code_mode = false;
	private List<runes> try_code = new List<runes>();

	[Header("Dependencies")]
	public AudioSource bg_music;
	public ping ping;
	public playerSpaceController player;
	public Camera camera;

	private void Start()
	{
		//btns = FindObjectsByType<RuneButton>(FindObjectsSortMode.None).ToList();
		int index = 0;
		foreach (runes rune in Enum.GetValues(typeof(runes)))
		{
			if (!data.Instance.runes_imgs.ContainsKey(rune))
				data.Instance.runes_imgs.Add(rune, icons[index]);
			btns[index].rune = rune;
			btns[index].GetComponent<Image>().sprite = data.Instance.runes_imgs[rune];
			btns[index].Bind(this, display, value);
			index++;
		}
		
		// if too much btns
		for (; index < btns.Count; index++)
		{
			btns[index].GetComponent<Image>().sprite = icons[index];
			btns[index].Bind(this, display, value);
		}
		
		data.Instance.LoadRuneState(this);
	}

	private void OnDestroy()
	{
		data.Instance.SaveRuneState(this);
	}

	public void ActiveRune(runes _rune)
	{
		if (code_mode)
		{
			try_code.Add(_rune);
			if (_rune == runes.validate_rune_code || try_code.Count > 5)
				test_code();
			return;
		}

		Debug.Log("activate " + ToStr(_rune));
			
		switch (_rune)
		{
			case runes.sound_plus:
				bg_music.volume += 0.05f;
				if (bg_music.volume > 1)
					bg_music.volume = 1;
				break;
			case runes.sound_minus:
				bg_music.volume -= 0.05f;
				if (bg_music.volume < 0)
					bg_music.volume = 0;
				break;
			case runes.speed_plus:
				player.maxSpeed += 5;
				if (player.maxSpeed > 200)
					player.maxSpeed = 200;
				break;
			case runes.speed_minus:
				player.maxSpeed -= 5;
				if (player.maxSpeed < -100)
					player.maxSpeed = -100;
				break;
			case runes.radar_switch:
				ping.visible = true;
				break;
			case runes.zoom_plus:
				camera.orthographicSize += 0.1f;
				if (camera.orthographicSize > 16)
					camera.orthographicSize = 16;
				break;
			case runes.zoom_minus:
				camera.orthographicSize -= 0.1f;
				if (camera.orthographicSize < 7)
					camera.orthographicSize = 7;
				break;
			case runes.start_rune_code:
				code_mode = true;
				break;
			case runes.validate_rune_code:
				break;
			case runes.rotation_speed_plus:
				player.rotationSpeed += 2;
				if (player.rotationSpeed > 70)
					player.rotationSpeed = 70;
				break;
			case runes.rotation_speed_minus:
				player.rotationSpeed -= 2;
				if (player.rotationSpeed < -70)
					player.rotationSpeed = -70;
				break;
			case runes.activate_planetes:
				data.Instance.visited.Clear();
				break;
			default:
				return;
		}
	}

	private void test_code()
	{
		if (try_code.Count != 5)
		{
			value.text = "wrong destination";
			code_mode = false;
			return;
		}
		
		for (int i = 0 ; i < 3; ++i)
		{
			if (try_code[i] != data.Instance.code[i])
			{
				value.text = "wrong destination";
				code_mode = false;
				return;
			}
		}

		value.text = "Teleportation Activation";
		display.text = "...Be Ready ...";
		StartCoroutine(gameOver());
	}

	private IEnumerator gameOver()
	{
		display.text = "in 5";
		yield return new WaitForSeconds(1);
		display.text = "in 4";
		yield return new WaitForSeconds(1);
		display.text = "in 3";
		yield return new WaitForSeconds(1);
		display.text = "in 2";
		yield return new WaitForSeconds(1);
		display.text = "in 1";
		yield return new WaitForSeconds(1);
		
		SceneManager.LoadScene("GameOver");
	}


	public string ToValue(runes _rune)
	{
		switch (_rune)
		{
			case runes.sound_plus:
				return bg_music.volume.ToString();
			case runes.sound_minus:
				return bg_music.volume.ToString();
			case runes.speed_plus:
				return player.maxSpeed.ToString();
			case runes.speed_minus:
				return player.maxSpeed.ToString();
			case runes.radar_switch:
				return ping.visible ? "active" : "inactive";
			case runes.zoom_plus:
				return camera.orthographicSize.ToString();
			case runes.zoom_minus:
				return camera.orthographicSize.ToString();
			case runes.start_rune_code:
				return "need 5 Runes";
			case runes.validate_rune_code:
				return "Validate the code";
			case runes.rotation_speed_plus:
				return player.rotationSpeed.ToString();
			case runes.rotation_speed_minus:
				return player.rotationSpeed.ToString();
			default:
				return "??????????????";
		}
	}

	public static string ToStr(runes _rune)
	{
		switch (_rune)
		{
			case runes.sound_plus:
				return "sound +";
			case runes.sound_minus:
				return "sound -";
			case runes.speed_plus:
				return "max speed +";
			case runes.speed_minus:
				return "max speed -";
			case runes.radar_switch:
				return "switch radar";
			default:
				return _rune.ToString();
		}
	}
}