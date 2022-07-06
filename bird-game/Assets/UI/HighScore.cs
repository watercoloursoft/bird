using System;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        text.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

}