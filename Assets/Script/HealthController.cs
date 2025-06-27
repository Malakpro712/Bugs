using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.U2D;
using Unity.VisualScripting;

public class HealthController : MonoBehaviour
{
    public Slider slider;
    public GameObject gameOver;
    private static float sliderValue = 10;
    private float maxHealth = 10;
    public int lives = 3;
    public TextMeshProUGUI livesText;
    private GameObject[] healths;
    private int health;

    private void Start()
    {
        slider.value = sliderValue;
        UpdateLivesUI();
    }

    void Update()
    {
        if (lives == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            slider.value -= 3;
            sliderValue = slider.value;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            slider.value -= 1;
            sliderValue = slider.value;
        }
        if (slider.value == 0)
        {
            healths = GameObject.FindGameObjectsWithTag("Health");
            health = healths.Length;
            healths.ElementAt(0).gameObject.SetActive(false);
            lives--;
            UpdateLivesUI();
            IncreaseSlider();
            if (lives == 0)
            {
                gameOver.SetActive(true);
                // Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Medicine"))
        {
            IncreaseSlider();
            Destroy(collision.gameObject);
        }
    }
    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives;
    }
    void IncreaseSlider()
    {
        slider.value = maxHealth;
        sliderValue = slider.value;
    }
}
