using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Text _gameOverText;

    [SerializeField]
    private Image _livesImage;

    [SerializeField]
    private Sprite[] _livesSprites;

    private GameManager _gameManager;

    [SerializeField]
    private Text _restartText;
    void Start()
    {

        

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _restartText.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(false);
        _scoreText.text = "Score:" + 0;

        if(_gameManager == null)
        {
            Debug.Log("Game Manager is null");
        }
    }


    public void addToScore(int score)
    {
        _scoreText.text = "Score:" + score.ToString();
    }

    public void updateLives(int currentLives)
    {
        _livesImage.sprite = _livesSprites[currentLives];

        if(currentLives == 0)
        {
            gameOver();
        }
    }


    public void gameOver()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickRoutine());
    }

    IEnumerator GameOverFlickRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);

        }
    }


}
