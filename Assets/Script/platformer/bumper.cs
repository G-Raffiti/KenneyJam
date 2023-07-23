using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class bumper : MonoBehaviour
{
    public playerPlatformController player;
    public AudioSource audio;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            player.Bump();
            audio.Play();
        }
    }
	
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            player.has_control = true;
        }
    }
}
