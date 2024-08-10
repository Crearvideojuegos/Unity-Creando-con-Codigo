
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    private Button _button;
    private GameManagerX gameManagerX;
    public int difficulty;

    // Start is called before the first frame update
    private void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    /* When a _button is clicked, call the StartGame() method
     * and pass it the difficulty value (1, 2, 3) from the _button 
    */
    private void SetDifficulty()
    {
        gameManagerX.StartGame(difficulty);
    }



}
