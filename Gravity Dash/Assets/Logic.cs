using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject VictoryScreen;
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void gameOver()
    {
        GameOverScreen.SetActive(true);

    }

    public void victory()
    {
        VictoryScreen.SetActive(true);

    }
}
