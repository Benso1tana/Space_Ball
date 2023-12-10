using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject looseMenu;
    [SerializeField] GameObject winMenu;
    public GameObject pauseButton;

    void Start()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        looseMenu.SetActive(false);
    }

    public void Pause()
    {
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadSceneAsync(0);
        looseMenu.SetActive(false);
        Time.timeScale = 1;
    }

     public void Resume()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        pauseButton.SetActive(true);
        looseMenu.SetActive(false);
        winMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Next()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Avertissement : Aucune scène suivante dans le Build Settings.");
        }
        winMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }
}
