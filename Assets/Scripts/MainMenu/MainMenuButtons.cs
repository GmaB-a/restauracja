using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
