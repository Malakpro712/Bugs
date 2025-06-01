using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public Slider slider;
    public GameObject gameOver;
    private static float sliderValue = 10;
    private float maxHealth = 10;
    void Start()
    {
        slider.value = sliderValue;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            slider.value -= 1;
            sliderValue = slider.value;
        }
        if (slider.value == 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Medicine"))
        {
            slider.value = maxHealth;
            sliderValue = slider.value;
            Destroy(collision.gameObject);
        }
    }
}
