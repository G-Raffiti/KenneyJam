using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class tp : MonoBehaviour
{
	private GameObject player;
	public GameObject beem;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player")) return;

		beem.SetActive(true);
		player = other.gameObject;
		player.GetComponent<Rigidbody2D>().simulated = false;
		StartCoroutine(beem_anim());
	}

	private void Update()
	{
		if (player == null) return;
		player.transform.position += Vector3.up * Time.deltaTime;
	}

	IEnumerator beem_anim()
	{
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("Space");
	}
}