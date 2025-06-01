using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseHeath : MonoBehaviour
{
    public int lives = 5;
    public TextMeshProUGUI livesText;

    public void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            lives--;
            UpdateLivesUI();
        }
    }

    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives;
    }
}
