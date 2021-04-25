using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace Burak.Scripts
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        public int mainLevelIndex = 1;

        public GameObject mainMenu;
        public GameObject settings;
        public GameObject inGame;
        public GameObject pauseMenu;
        public GameObject endGame;
        public GameObject credits;

        public AudioMixer audioMixer;

        private bool isPaused;

        private void Awake()
        {
            if(!instance)
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            BackToMenu();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(!isPaused)
                {
                    PauseGame();
                }
                else if(isPaused)
                {
                    ContinueGame();
                }
            }
        }

        public void SetVolume(float sliderValue)
        {
            sliderValue = Mathf.Log10(sliderValue) * 20;
            audioMixer.SetFloat("MasterVolume", sliderValue);
        }

        public void StartGame()
        {
            CloseAllPages();
            SceneManager.LoadScene(mainLevelIndex);
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void PauseGame()
        {
            isPaused = true;
            pauseMenu.SetActive(true);

        }

        public void ContinueGame()
        {
            isPaused = false;
            pauseMenu.SetActive(false);
        }

        public void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void SettingsPage()
        {
            CloseAllPages();
            // activate only credits
            settings.SetActive(true);
        }

        public void CreditsPage()
        {
            CloseAllPages();
            // activate only credits
            credits.SetActive(true);
        }

        public void BackToMenu()
        {
            CloseAllPages();
            // activate only menu
            mainMenu.SetActive(true);
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void CloseAllPages()
        {
            mainMenu.SetActive(false);
            settings.SetActive(false);
            inGame.SetActive(false);
            pauseMenu.SetActive(false);
            endGame.SetActive(false);
            credits.SetActive(false);
        }
    }
}

