using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Persistence;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Encounter");
        SessionData.Reset();
    }

    public void quit()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("StartMenu");

    }
}
