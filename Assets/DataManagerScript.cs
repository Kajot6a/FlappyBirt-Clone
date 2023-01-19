using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManagerScript : MonoBehaviour
{
    
    public int highScore;

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
}
