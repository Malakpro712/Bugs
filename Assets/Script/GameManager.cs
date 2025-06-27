using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int currentLevel = 0;
    void Update()
    {
        if (checkFinish())
        {
            currentLevel++;
            NextLevel();
        }
    }

    bool checkFinish()
    {
        GameObject[] finishs = GameObject.FindGameObjectsWithTag("Finish");
        return finishs.Length == 0;
    }

    void NextLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
