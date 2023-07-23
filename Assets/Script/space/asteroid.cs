using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class asteroid : MonoBehaviour
{
	public Rigidbody2D rb;
	public SpriteRenderer sprite;
	public bool is_special = false;
	public float lifeTime = 10;
	public AudioSource audio;

	public void launch(Vector3 destination)
	{
		if (is_special)
			sprite.color = Color.green;
		transform.localScale *= Random.Range(0.8f, 3);
		rb.velocity = (Vector2)(destination - transform.position).normalized * Random.Range(2, 10);
	}

	public void Update()
	{
		lifeTime -= Time.deltaTime;
		if (lifeTime < 0)
			Destroy(this);
	}

	private void OnCollisionEnter(Collision other)
	{
		audio.Play();
	}
}
