using UnityEngine;
using UnityEngine.SceneManagement;

// Script written by Carl Moya

public class GameManager : MonoBehaviour
{
    // Fields

    [HideInInspector]
    public bool isPaused = false;

    public GameObject pauseButton;

    // Methods

    private void Start()
    {
        Pause();
    }

    public void EnablePause()
    {
        pauseButton.SetActive(true);
    }

    public void DisablePause()
    {
        pauseButton.SetActive(false);
    }

    public void Pause()
    {
        isPaused = true;

        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        isPaused = false;

        Time.timeScale = 1f;
    }

    public void Die()
    {

    }

    public void Win()
    {

    }

    public void Restart()
    {
        Time.timeScale = 1f;

        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
