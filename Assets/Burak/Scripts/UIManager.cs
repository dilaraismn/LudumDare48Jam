using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Burak.Scripts
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        public int mainLevelIndex = 1;

        public GameObject mainMenu;
        public GameObject inGame;
        public GameObject pauseMenu;
        public GameObject endGame;
        public GameObject credits;

        private void Awake()
        {
            if(!instance)
            {
                instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            BackToMenu();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartGame()
        {
            SceneManager.LoadScene(mainLevelIndex);
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Pause()
        {
            pauseMenu.SetActive(true);
        }

        public void Continue()
        {
            pauseMenu.SetActive(false);
        }

        public void CreditsPage()
        {
            mainMenu.SetActive(false);
            pauseMenu.SetActive(false);
            endGame.SetActive(false);
            inGame.SetActive(false);
            // activate only credits
            credits.SetActive(true);
        }

        public void BackToMenu()
        {
            credits.SetActive(false);
            pauseMenu.SetActive(false);
            endGame.SetActive(false);
            inGame.SetActive(false);
            // activate only menu
            mainMenu.SetActive(true);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}

