using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject pausePanel;
    public bool startPausedOnMainMenu = true;

    private bool isPaused = false;
    private bool hasStartedGame = false;

    private static bool loadMainMenuOnStart = false;
    private static bool hasLoadedOnce = false;

    void Start()
    {
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        bool shouldShowMainMenu = false;

        if (loadMainMenuOnStart)
        {
            shouldShowMainMenu = true;
            loadMainMenuOnStart = false;
        }
        else if (!hasLoadedOnce && startPausedOnMainMenu)
        {
            shouldShowMainMenu = true;
        }

        hasLoadedOnce = true;

        if (shouldShowMainMenu)
        {
            ShowMainMenu();
        }
        else
        {
            if (mainMenuPanel != null)
                mainMenuPanel.SetActive(false);

            hasStartedGame = true;
            isPaused = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        if (!hasStartedGame) return;
        if (pausePanel == null) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void ShowMainMenu()
    {
        hasStartedGame = false;
        isPaused = true;
        Time.timeScale = 0f;

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (pausePanel != null)
            pausePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        hasStartedGame = true;
        isPaused = false;
        Time.timeScale = 1f;

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (pausePanel != null)
            pausePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null)
            pausePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        loadMainMenuOnStart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        loadMainMenuOnStart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}