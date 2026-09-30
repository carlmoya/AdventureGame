using UnityEngine;
using UnityEngine.SceneManagement;

// Script written by Carl Moya

public class GameManager : MonoBehaviour
{
    // Fields

    [HideInInspector] public bool isPaused = false;

    public GameObject pauseButton;
    public GameObject loseScreen;
    public GameObject winScreen;

    private Collisions collisions;

    // Methods

    private void Start()
    {
        collisions = GameObject.FindFirstObjectByType<Collisions>();

        Pause();
    }

    private void Update()
    {
        CheckDeath();
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

    private void CheckDeath()
    {
        if (collisions.currentEnergy <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        DisablePause();

        Pause();

        loseScreen.SetActive(true);
    }

    public void Win()
    {
        DisablePause();

        Pause();

        winScreen.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;

        PuzzleInteractable.currentRiddle = 1;

        SceneManager.LoadScene(CurrentScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Return Methods

    public Scene CurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        return currentScene;
    }
}
