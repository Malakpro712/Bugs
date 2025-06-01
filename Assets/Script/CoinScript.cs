using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int count;
    void Start()
    {
        count = 0;
        scoreText.text = "Coins: " + count.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            count++;
            scoreText.text = "Coins: " + count.ToString();
            Destroy(collision.gameObject);
        }
    }
}
