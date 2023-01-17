using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public AudioSource mainGameMusic;
    public AudioSource policeAfterFoodTruck;
    public AudioSource hiszpanDeath;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public int customerPerGame;
    public int CurrentCustomer;

    private void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        CurrentCustomer = 1;
    }

    public void AddCurrentCustomer()
    {
        CurrentCustomer++;
        if (CurrentCustomer - 1 == customerPerGame) EndGame();
    }

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject videoImage;

    [SerializeField] private VideoClip chineseDeath;
    [SerializeField] private VideoClip spanishDeath;
    [SerializeField] private VideoClip indianDeath;
    [SerializeField] private VideoClip win;
    [SerializeField] private VideoClip gameOver;

    public bool chineseDead;
    public bool spanishDead;
    public bool indianDead;
    public bool civiliansDead;

    private bool videoPlaying;
    public void CheckForConcurrency()
    {
        if (CustomerManager.Instance.CheckCustomerNumbers(CustomerManager.Instance.chineseNum))
        {
            videoPlayer.clip = chineseDeath;
            videoImage.SetActive(true);
            videoPlayer.Play();
            chineseDead = true;
            mainGameMusic.Stop();
        }
        else if (CustomerManager.Instance.CheckCustomerNumbers(CustomerManager.Instance.spanishNum))
        {
            videoPlayer.clip = spanishDeath;
            videoImage.SetActive(true);
            videoPlayer.Play();
            spanishDead = true;
            mainGameMusic.Stop();
            hiszpanDeath.PlayDelayed(3);
        }
        else if (CustomerManager.Instance.CheckCustomerNumbers(CustomerManager.Instance.indianNum))
        { 
            videoPlayer.clip = indianDeath;
            videoImage.SetActive(true);
            videoPlayer.Play();
            indianDead = true;
            mainGameMusic.Stop();
        }
        else
        {
            civiliansDead = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        if (chineseDead && indianDead && spanishDead && !civiliansDead)
            videoPlayer.clip = win;
        else 
        {
            videoPlayer.clip = gameOver;
            mainGameMusic.Stop();
            policeAfterFoodTruck.Play();
        }
        

        videoImage.SetActive(true);
        videoPlayer.Play();
        StartCoroutine(WaitTillSceneChange());
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        videoImage.SetActive(false);
        mainGameMusic.Play();
    }

    IEnumerator WaitTillSceneChange()
    {
        yield return new WaitForSeconds(12.6f);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
