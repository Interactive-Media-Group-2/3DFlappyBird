using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Lose : MonoBehaviour
{
    [SerializeField] GameObject restartButton, board, backButton;
    public bool stop;
    public TMP_Text scoreBoard, finalScore;
    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetStop())
        {
            restartButton.SetActive(true);
            board.SetActive(true);
            finalScore.gameObject.SetActive(true);
            scoreBoard.gameObject.SetActive(true);
            backButton.SetActive(true);
            Stop();
        }
        else
        {
            restartButton?.SetActive(false);
            board.SetActive(false);
            finalScore.gameObject.SetActive(false);
            backButton.SetActive(false);
            Continue();
        }
        scoreBoard.text = string.Format("score: {00}", score);
        finalScore.text = string.Format("Your final score is: {00}", score);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Stop()
    {
        Time.timeScale = 0;
    }
    void Continue()
    {
        Time.timeScale = 1;
    }
    public bool GetStop()
    {
        return stop;
    }
    public void SetStop(bool isStop)
    {
        stop = isStop;
    }
    public void AddScore()
    {
        score++;
    }
}
