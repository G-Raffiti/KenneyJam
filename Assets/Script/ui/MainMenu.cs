using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Transform planete;
	public Image bg;
	public Camera cam;
	void Update()
	{
		planete.transform.Rotate(new Vector3(0,0,1), 7 * Time.deltaTime);
	}
	public void Play()
	{
		StartCoroutine(play());
	}

	private IEnumerator play()
	{
		while (cam.orthographicSize > 0.2f)
		{
			cam.orthographicSize -= Time.deltaTime;
			bg.color -= new Color(Time.deltaTime, Time.deltaTime, Time.deltaTime, 0f);
			yield return new WaitForEndOfFrame();
		}
		SceneManager.LoadScene("Intro");
	}
}
