using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    private Button _button;
    private GameManager _gameManager;
    public int Difficulty;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void SetDifficulty()
    {
        _gameManager.StartGame(Difficulty);
    }
}
