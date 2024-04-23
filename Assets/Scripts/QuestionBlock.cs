using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    [SerializeField] Sprite hitted;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = hitted;
        GetComponent<Collider2D>().enabled = false;
        
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<DebugManager>().PauseGame();
        }
    }
}
