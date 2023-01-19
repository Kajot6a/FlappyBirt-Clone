using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SingleDataManager : MonoBehaviour
{
    static SingleDataManager instance;
    public int highScore;
    // Start is called before the first frame update
    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int readHighScore() {
        string fileName = "data.json";
        string jsonString = File.ReadAllText(fileName);
        JsonUtility.FromJsonOverwrite(jsonString, this);
        return highScore;
    }

    public void writeHighScore(int score) {
        string fileName = "data.json";
        highScore = score;

        string hSString = JsonUtility.ToJson(this);

        File.WriteAllText(fileName, hSString);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
