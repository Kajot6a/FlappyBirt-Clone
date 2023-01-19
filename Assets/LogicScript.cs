using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public string fileName = "highScore.json";
    public DataManagerScript data;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManagerScript>();
    }

    public void addScore(int scoreToAdd) {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        int currentHighScore = 0;

        currentHighScore = data.readHighScore();
        Debug.Log(currentHighScore);

        if ( playerScore > currentHighScore ) {
            // string highScore = playerScore.ToString();
            // currentHighScore = playerScore;
            // string hSString = JsonUtility.ToJson(currentHighScore);

            // File.WriteAllText(fileName, hSString);
            data.writeHighScore(playerScore);
        }

        gameOverScreen.SetActive(true);
    }

    public void mainMenu() {
        SceneManager.LoadScene("StartScene");
    }
}
