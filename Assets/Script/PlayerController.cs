using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int speed = 10;
    private int force = 7;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontal);
        sprite.flipX = horizontal < 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}
