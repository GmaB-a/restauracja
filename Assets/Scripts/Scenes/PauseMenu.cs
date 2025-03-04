using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseBackground;
    [SerializeField] GameObject pauseButton;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseBackground.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseBackground.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    
}
