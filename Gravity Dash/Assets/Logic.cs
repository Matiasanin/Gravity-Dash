using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject VictoryScreen;
    public bool game = true;
    public AudioSource audioSource;

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        game = true;
    }


      
        

    public void gameOver()
    {
        GameOverScreen.SetActive(true);
        game = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void victory()
    {
        VictoryScreen.SetActive(true);
        game = false;
    }
}
