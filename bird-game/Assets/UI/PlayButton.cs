
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject scoreUI;
    
    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Destroy(ui);
        GameState.instance.Begin();
        scoreUI.SetActive(true);
    }
}