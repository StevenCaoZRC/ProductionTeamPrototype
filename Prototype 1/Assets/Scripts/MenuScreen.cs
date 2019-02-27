using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject HowToPlayUI;
    public GameObject CreditsMenuUI;

    public void Start()
    {
        MainMenuUI.SetActive(true);
        HowToPlayUI.SetActive(false);
        CreditsMenuUI.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level(Steven)");
    }

    public void LoadMainMenu()
    {
        MainMenuUI.SetActive(true);
        HowToPlayUI.SetActive(false);
        CreditsMenuUI.SetActive(false);
    }
    public void LoadHelpMenu()
    {
        HowToPlayUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void LoadCreditsMenu()
    {
        CreditsMenuUI.SetActive(true);
        HowToPlayUI.SetActive(false);
        MainMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
