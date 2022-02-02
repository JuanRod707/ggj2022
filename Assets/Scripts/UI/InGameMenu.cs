using Assets.Scripts.Persistence;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class InGameMenu : MonoBehaviour
    {
        public void OnRestart()
        {
            SessionData.Reset();
            SceneManager.LoadScene("Encounter");
        }

        public void OnBackToMenu() => SceneManager.LoadScene("StartMenu");
    }
}
