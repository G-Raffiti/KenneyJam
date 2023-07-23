using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class tp : MonoBehaviour
{
	private GameObject player;
	private Rigidbody2D rb_player;
	public SpriteRenderer beem;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player")) return;
		Debug.Log("end level triggered");
		beem.enabled = true;
		player = other.gameObject;
		rb_player = player.GetComponent<Rigidbody2D>();
		rb_player.gravityScale = -0.2f;
		rb_player.freezeRotation = false;
		player.GetComponent<playerPlatformController>().has_control = false;
		StartCoroutine(beem_anim());
	}

	private void Update()
	{
		if (player == null) return;
		rb_player.velocity += Vector2.up * (Time.deltaTime * Time.deltaTime);
	}

	IEnumerator beem_anim()
	{
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("Space");
	}
}