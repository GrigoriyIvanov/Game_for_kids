using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEvent : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public delegate void Restart();
    public static event Restart OnRestart;
    private void Start()
    {
        LvlCellAmount.OnGamePased += OnGamePased;
    }
    private void OnGamePased()
    {
        _panel.SetActive(true);
    }
    public void GameRestart()
    {
        OnRestart?.Invoke();
    }
    
}
