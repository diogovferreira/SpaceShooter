using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
        _scoreText.text = "Score:" + 0;
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
        _gameOverText.gameObject.SetActive(true);
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
