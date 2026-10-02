using UnityEngine;
using TMPro; //para poder usar el texto

public class MaxScript : MonoBehaviour
{
    public TextMeshProUGUI max_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        max_text.SetText("" + PlayerPrefs.GetInt("max"));
    }
}
