using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class backward : MonoBehaviour
{
    public TilemapCollider2D collider;
    public playerPlatformController player;
    private Collider2D player_collider;
    public bool left = true;

    private void Start()
    {
        player_collider = player.GetComponent<Collider2D>();
    }

    private void Update()
    {
        // if (collider.IsTouching(player_collider))
        //     player.goBack(left ? -1 : 1);
        // else if (!player.has_control)
        //     player.has_control = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            player.goBack(left ? -1 : 1);
        }
    }
	
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            player.has_control = true;
        }
    }
}
