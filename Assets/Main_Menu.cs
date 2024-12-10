using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject charmenu;
    public GameObject canvas;
    public void PlayGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void charselect()
    {
        
        charmenu.SetActive(true);
        canvas.SetActive(false);
    }

    public void Quitgame()
    {
        Application.Quit();
        Debug.Log("You have Quit");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
