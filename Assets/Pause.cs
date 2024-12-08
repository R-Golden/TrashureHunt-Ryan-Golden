using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{


    public static bool GameisPaused = false;
  

    public GameObject pausemenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused) 
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }


    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }


    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main menu");
    }



    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
