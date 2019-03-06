using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject switchCharacter;
    public GameObject pauseButton;
    
    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Pause();
        }
        
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        switchCharacter.SetActive(false);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void Resume()
    {
        pauseButton.SetActive(true);
        switchCharacter.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(GameManager.GetSceneName());
        Time.timeScale = 1f;
        gamePaused = false;
    }


    public void LoadMainMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
