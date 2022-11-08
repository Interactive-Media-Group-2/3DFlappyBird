using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Lose : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    public bool stop;
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
            Stop();
        }
        else
        {
            restartButton?.SetActive(false);
            Continue();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        movement.score = 0;
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
}
