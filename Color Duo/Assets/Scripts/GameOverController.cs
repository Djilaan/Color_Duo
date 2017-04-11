using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverController : MonoBehaviour {

    public Text highScoreLabel;
    public Text currentScoreLabel;

    // Use this for initialization
    void Start () {
        highScoreLabel.text = PlayerPrefs.GetInt("highScore").ToString();
        currentScoreLabel.text = PlayerPrefs.GetInt("currentScore").ToString();
	}
	
    public void loadGame()
    {
        SceneManager.LoadScene("game");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
