using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator fadeAnimator;
    private int levelToLoad;

    public void LoadToNextLevel()
    {
        LoadToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        fadeAnimator.SetTrigger("Start");
    }

    public void OnLoadComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Retry()
    {
        PlayerController.PlayerIsDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
