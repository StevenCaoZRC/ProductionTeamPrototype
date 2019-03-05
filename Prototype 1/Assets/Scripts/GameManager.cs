using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public string m_currentScene = "MainMenu";

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    static public GameManager GetInstance()
    {
        return instance;
    }

    static public void SetSceneName(string _sceneName)
    {
        m_currentScene = _sceneName;
    }

    static public string GetSceneName()
    {
        return m_currentScene;
    }
}
