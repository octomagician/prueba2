using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI texto_score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //score = 0;
        //PlayerPrefs.SetInt("score", 0); //un tipo de archivo persistente para strings, int, etc
        //
    }

    // Update is called once per frame
    void Update()
    {
        texto_score.SetText("" + GameManagerScript.score);
    }
}
