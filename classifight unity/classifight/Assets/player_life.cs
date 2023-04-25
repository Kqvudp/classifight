using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_life : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rg;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fallout"))
        {
            Die();
        }
    }
    private void Die()
    {
        rg.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
