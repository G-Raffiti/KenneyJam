using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class backward : MonoBehaviour
{
    public playerPlatformController player;
    public bool left = true;
    
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
