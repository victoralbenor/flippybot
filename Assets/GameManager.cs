using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEvent onResumeGame;
    public UnityEvent onGameOver;

    private bool _isGameOver;
    private void Start()
    {
        _isGameOver = false;
    }

    private void Update()
    {
        if (!_isGameOver && Time.timeScale == 0 && Input.GetButtonDown("Fire1"))
            ResumeGame();
        if(_isGameOver && Input.GetButtonDown("Fire1"))
            RestartGame();
    }
    
    public void GameOver()
    {
        _isGameOver = true;
        Time.timeScale = 0f;
        onGameOver.Invoke();
    }
    
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        onResumeGame.Invoke();
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    
}
