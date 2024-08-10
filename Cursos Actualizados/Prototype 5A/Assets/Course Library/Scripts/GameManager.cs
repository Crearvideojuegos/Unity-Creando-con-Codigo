using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets;
    private float _spawnRate = 1.0f;
    public TextMeshProUGUI ScoreText;
    private int _score;
    public TextMeshProUGUI GameOverText;

    public bool IsGameActive;
    public Button RestartButton;

    public GameObject TitleScreen;

    public void StartGame(int difficulty)
    {
        IsGameActive = true;
        StartCoroutine(SpawnTarget());
        _score = 0;
        UpdateScore(0);
        TitleScreen.gameObject.SetActive(false);
        _spawnRate /= difficulty;
    }

    private IEnumerator SpawnTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        ScoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        IsGameActive = false;
        RestartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
