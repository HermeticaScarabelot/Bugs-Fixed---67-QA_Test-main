using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            player.TouchedGround();
        }
    }

    //To prevent any unexpected Bugs
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground") && !player.isGrounded)
        {
            player.TouchedGround();
        }
    }
}
