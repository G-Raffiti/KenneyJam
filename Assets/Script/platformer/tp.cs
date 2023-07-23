using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class tp : MonoBehaviour
{
	private GameObject player;
	private Rigidbody2D rb_player;
	public SpriteRenderer beem;
	[FormerlySerializedAs("audio")] public AudioSource audio_scr;
	public audiofade ambiance;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player")) return;
		ambiance.Fade_to(0);
		beem.enabled = true;
		audio_scr.Play();
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
		CodeParts.Instance.AddClue(data.Instance.runes[Random.Range(0, 12)]);
		SceneManager.LoadScene("Space");
	}
}