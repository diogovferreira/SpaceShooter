using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool _isGameOver;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && _isGameOver)
        {
            restartLevel();
        }
    }


    public void GameOver()
    {
        _isGameOver = true;
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(1);

    }
}
