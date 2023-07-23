using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class bumper : MonoBehaviour
{
    public TilemapCollider2D collider;
    public playerPlatformController player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            player.Bump();
        }
    }
	
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            player.has_control = true;
        }
    }
}
