using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

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

        public ColorImages[] colorImages;

        public TextMeshProUGUI healthText;
        public Slider healthSlider;
        public Gradient healthGradientColor;
        public Image healthFillImage;

        public int health = 100;

        private bool isPaused;
        private bool isGameRunning;

        [System.Serializable]
        public class ColorImages
        {
            public Image image;
            public Color[] colors;
        }

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
            /*if (Input.GetKeyDown(KeyCode.Escape))
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

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Damaged.");
                health = health + 10;
                UIManager.instance.SetHealthBar(health);
                UIManager.instance.SetHealthText(health);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("Healed.");
                health = health - 10;
                UIManager.instance.SetHealthBar(health);
                UIManager.instance.SetHealthText(health);
            }


            if (Input.GetKeyDown(KeyCode.Z))
            {
                SetUIColorByIndex(0, 1);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                SetUIColorByIndex(1, 2);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                SetUIColorByIndex(2, 0);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                SetUIColorByIndex(3, 2);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                SetUIColorByIndex(4, 1);
            }*/

        }

        public void SetUIColorByIndex(int imageIndex, int colorIndex)
        {
            Color color = colorImages[imageIndex].colors[colorIndex];
            colorImages[imageIndex].image.color = color;
        }

        public void SetMusicVolume(float sliderValue)
        {
            sliderValue = Mathf.Log10(sliderValue) * 20;
            audioMixer.SetFloat("MusicVolume", sliderValue);
        }

        public void SetSFXVolume(float sliderValue)
        {
            sliderValue = Mathf.Log10(sliderValue) * 20;
            audioMixer.SetFloat("SFXVolume", sliderValue);
        }

        public void SetHealthBar(float _health)
        {
            healthSlider.value = _health;
            healthFillImage.color = healthGradientColor.Evaluate(healthSlider.normalizedValue);
        }

        public void SetHealthText (float _health)
        {
            healthText.text = "Health: " + _health.ToString();
        }

        public void StartGame()
        {
            CloseAllPages();
            inGame.SetActive(true);
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

        public void EndgamePage()
        {
            CloseAllPages();
            // activate only credits
            endGame.SetActive(true);
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
            //inGame.SetActive(false);
            pauseMenu.SetActive(false);
            endGame.SetActive(false);
            credits.SetActive(false);
        }
    }
}

