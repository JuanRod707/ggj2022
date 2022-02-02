using Assets.Scripts.Persistence;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class MenuNavigation : MonoBehaviour
    {
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject credits;
        [SerializeField] GameObject tutorial;

        public void OnPlay()
        {
            SessionData.Reset();
            SceneManager.LoadScene("Encounter");
        }

        public void OnQuit() => Application.Quit();

        public void OnBackToMenu()
        {
            HideAllMenus();
            mainMenu.SetActive(true);
        }

        public void OnCredits()
        {
            HideAllMenus();
            credits.SetActive(true);
        }

        public void OnTutorial()
        {
            HideAllMenus();
            tutorial.SetActive(true);
        }

        void HideAllMenus()
        {
            mainMenu.SetActive(false);
            credits.SetActive(false);
            tutorial.SetActive(false);
        }
    }
}
