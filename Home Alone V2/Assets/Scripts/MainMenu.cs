using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        //play the game by pressing start
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //choosing next scene in queue
    }

    public void ShowCredits()
    {
        //Go to credits scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void ReturntoMenu()
    {
        //return to main menu from main game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ReturnCredits()
    {
        //return to main menu from credits scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void QuitGame()
    {
        //close the game - won't work in Unity Editor
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
