using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public bool IsPlaying;
    public static GameState instance;

    public int Score;

    private float elapsedTime;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPlaying)
            return;

        elapsedTime += Time.deltaTime;
        if (!(elapsedTime > 1f)) return;
        elapsedTime -= 1f;
        Score += 1;
    }

    public void Begin()
    {
        IsPlaying = true;
        Score = 0;
        elapsedTime = 0f;
        Time.timeScale = 1f;
    }
    
    public void Reload()
    {
        IsPlaying = false;
        Time.timeScale = 0f;

        var oldScore = PlayerPrefs.GetInt("HighScore", 0);
        if (Score > oldScore)
            PlayerPrefs.SetInt("HighScore", Score);
        
        SceneManager.LoadScene(0);
    }
}
