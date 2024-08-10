using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI TimeText;

    public GameObject TitleScreen;
    public Button RestartButton; 

    public List<GameObject> TargetPrefabs;

    private int _score;
    private float _spawnRate = 1.5f;
    public bool IsGameActive;

    private float _spaceBetweenSquares = 2.5f; 
    private float _minValueX = -3.75f; //  x value of the center of the left-most square
    private float _minValueY = -3.75f; //  y value of the center of the bottom-most square

    private float _timeRemaining = 60f;
    
    // Start the game, remove title screen, reset _score, and adjust _spawnRate based on difficulty button clicked
    public void StartGame(int difficulty)
    {
        if(difficulty == 1)
        {
            _spawnRate /= 1;

        } else if(difficulty == 2)
        {
            _spawnRate /= 2;
        } else if(difficulty == 3)
        {
            _spawnRate /= 3;
        }
        IsGameActive = true;
        StartCoroutine(SpawnTarget());
        _score = 0;
        UpdateScore(0);
        TitleScreen.SetActive(false);
    }

    private void Update() 
    {
        if(IsGameActive)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            } else {
                GameOver();
            }

            TimeText.text = "Time: " + _timeRemaining.ToString("f0");

        }

    }

    // While game is active spawn a random target
    private IEnumerator SpawnTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, TargetPrefabs.Count);

            if (IsGameActive)
            {
                Instantiate(TargetPrefabs[index], RandomSpawnPosition(), TargetPrefabs[index].transform.rotation);
            }
            
        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = _minValueX + (RandomSquareIndex() * _spaceBetweenSquares);
        float spawnPosY = _minValueY + (RandomSquareIndex() * _spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    private int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // Update _score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        ScoreText.text = $"Score: {_score}";

    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        IsGameActive = false;
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
