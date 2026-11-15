using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionPanel;
    private bool enPause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enPause) Cancel();
            else Pause();
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        enPause = true;
    }

    public void Cancel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        enPause = false;
    }

    public void ReturnMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Option()
    {
        pausePanel.SetActive(false);
        optionPanel.SetActive(true);
    }

    public void Back()
    {
        optionPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}
