using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLogicScript : MonoBehaviour
{
    public GameObject menuView;
    public GameObject highScoreView;
    public Text highScoreText;
    public DataManagerScript data;

    void Start()
    {
        data = GameObject.FindWithTag("Data").GetComponent<DataManagerScript>();
    }

    public void startGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void exitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }

    public void highScore() {
        menuView.SetActive(false);
        highScoreView.SetActive(true);

        highScoreText = GameObject.FindGameObjectWithTag("highScoreText").GetComponent<Text>();
        highScoreText.text = data.readHighScore().ToString();
    }

    public void menuBack() {
        menuView.SetActive(true);
        highScoreView.SetActive(false);
    }
}
