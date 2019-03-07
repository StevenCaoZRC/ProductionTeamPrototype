using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject HowToPlayUI;

    public GameObject CreditsUI;
    public GameObject CreditsP1;
    public GameObject CreditsP2;
    public GameObject Instr1;
    public GameObject Instr2;

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
        Instr1.SetActive(false);
        Instr2.SetActive(false);
        CreditsP1.SetActive(false);
        CreditsP2.SetActive(false);
    }
    public void LoadHelpMenu()
    {
        HowToPlayUI.SetActive(true);
        MainMenuUI.SetActive(false);
        CreditsUI.SetActive(false);
        CreditsP1.SetActive(false);
        CreditsP2.SetActive(false);
    }

    public void LoadCreditsMenu()
    {
        CreditsUI.SetActive(true);
        MainMenuUI.SetActive(false);
        HowToPlayUI.SetActive(false);
        CreditsP1.SetActive(true);
        CreditsP2.SetActive(false);
    }

    public void LoadCreditsMenu2()
    {
        CreditsUI.SetActive(true);
        MainMenuUI.SetActive(false);
        HowToPlayUI.SetActive(false);
        CreditsP1.SetActive(false);
        CreditsP2.SetActive(true);
    }

    public void LoadInstructions1()
    {
        CreditsUI.SetActive(false);
        MainMenuUI.SetActive(false);
        HowToPlayUI.SetActive(true);
        CreditsP1.SetActive(false);
        CreditsP2.SetActive(false);
        Instr1.SetActive(true);
        Instr2.SetActive(false);
    }

    public void LoadInstructions2()
    {
        CreditsUI.SetActive(false);
        MainMenuUI.SetActive(false);
        HowToPlayUI.SetActive(true);
        CreditsP1.SetActive(false);
        CreditsP2.SetActive(false);
        Instr1.SetActive(false);
        Instr2.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
