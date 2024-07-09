using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    public GameObject pausePanel;
    public Button pauseButton;
    public Button resumeButton;
    public Button mainMenuButton;
   
    private bool isPaused = false;
    public static bool IsGoMainMenu;
    private void Awake()
    {
        IsGoMainMenu = false;
    }
    void Start()
    {
        // Ensure the pause panel is inactive at the start
        pausePanel.SetActive(false);

        // Add listeners to the buttons
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        
        Time.timeScale = isPaused ? 0 : 1;
        InterstitialAdExample.instance.ShowAd();
    }

    void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void GoToMainMenu()
    {
        IsGoMainMenu = true;
       
        // Make sure to resume the game before loading the main menu
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); // Change "MainMenu" to the name of your main menu scene
        InterstitialAdExample.instance.ShowAd();
    }
}
