using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject HowToPlayUI;
    public GameObject CreditsUI;

    void Start()
    {
        MainMenuUI.SetActive(true);
        HowToPlayUI.SetActive(false);
        CreditsUI.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        MainMenuUI.SetActive(true);
        HowToPlayUI.SetActive(false);
        CreditsUI.SetActive(false);
    }
    public void LoadHelpMenu()
    {
        HowToPlayUI.SetActive(true);
        MainMenuUI.SetActive(false);
        CreditsUI.SetActive(false);
    }

    public void LoadCreditsMenu()
    {
        CreditsUI.SetActive(true);
        MainMenuUI.SetActive(false);
        HowToPlayUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
