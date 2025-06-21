using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private float speed = 0.01f;
    public Vector3[] positions;
    public GameObject Apple;
    public Slider slider;
    private int indexPosition;
    public SpriteRenderer sprite;
    private static float sliderValue = 3;
    private float maxHealth = 3;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * horizontal);
        //sprite.flipX = horizontal < 0;

        transform.position = Vector3.MoveTowards(transform.position, positions[indexPosition], speed);

        if (transform.position == positions[indexPosition])
        {
            if (indexPosition < positions.Length - 1)
            {
                indexPosition++;
                sprite.flipX = false;
            }
            else
            {
                indexPosition = 0;
                sprite.flipX = true;
            }
        }

        if ((slider.value == 1) && (Apple!= null) && (Apple.activeInHierarchy))
        {
            transform.position = Vector3.MoveTowards(transform.position, Apple.transform.position, speed);
        }

        if (slider.value == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slider.value -= 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            if (slider.value <= 2)
            {
                slider.value = maxHealth;
                sliderValue = slider.value;
                Destroy(collision.gameObject);
            }
        }
    }
}
