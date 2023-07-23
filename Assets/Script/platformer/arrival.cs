using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arrival: MonoBehaviour
{
	public playerPlatformController player;
	public SpriteRenderer beam;
	public GameObject end;
	private bool anim = false;
	public ComicsPrompter prompt;
	public List<string> character_reaction;

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(0.2f);
		prompt.display(character_reaction[0]);
	}

	private void Update()
	{
		if (player.IsGrounded() && !anim)
		{
			player.has_control = true;
			anim = true;
			prompt.display(character_reaction[1]);
		}
		else
			player.rb.velocity -= Vector2.up * (Time.deltaTime * Time.deltaTime);
		if (anim && beam.color.a > 0)
			beam.color = new(beam.color.r, beam.color.g, beam.color.b, beam.color.a - Time.deltaTime);
		else if (anim && Math.Abs(transform.position.y - end.transform.position.y) > 3)
			transform.position += new Vector3(0, (end.transform.position.y - transform.position.y) * Time.deltaTime); 
	}
}