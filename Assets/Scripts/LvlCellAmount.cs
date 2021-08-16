using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlCellAmount : MonoBehaviour
{
    private int _cellInLvlAmount;
    private int _currentLvl;
    private int _cellInRowAmount;

    public int CellInLvlAmount => _cellInLvlAmount;
    public int CurrentLvl => _currentLvl;
    public int CellInRowAmount => _cellInRowAmount;

    public delegate void GamePased();
    public static event GamePased OnGamePased;
    private void Start()
    {
        Cell.OnLevelPased += OnLvlPased;
        _currentLvl = 1;
        _cellInRowAmount = 3;
        _cellInLvlAmount = _currentLvl * _cellInRowAmount;
    }
    private void OnLvlPased()
    {
        _currentLvl++;
        _cellInLvlAmount = _currentLvl * _cellInRowAmount;
        if (_currentLvl == 4)
        {
            _currentLvl = 1;
            _cellInLvlAmount = _currentLvl * _cellInRowAmount;
            OnGamePased?.Invoke();
        }
    }
}
