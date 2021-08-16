using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cell;
    private int _currentLvl;
    private int _cellInLvlAmount;
    private int _cellInRowAmount;

    private float _gridStartX;
    private float _gridStartY;

    [SerializeField] private BundleAndGoalPeacker _bundleAndGoal;
    [SerializeField] private LvlCellAmount _lvlCellAmount;

    private void Start()
    {
        _gridStartX = -1.5f;
        BundleAndGoalPeacker.OnGoalPicked += SpawnCells;
        WinEvent.OnRestart += SpawnCells;
    }
    private void SpawnCells()
    {
        _cellInRowAmount = _lvlCellAmount.CellInRowAmount;
        _currentLvl = _lvlCellAmount.CurrentLvl;
        _cellInLvlAmount = _currentLvl * _cellInRowAmount;
        _gridStartY = 0.75f * _currentLvl - 0.75f;
        var cellNum = 0;
        for (int rowAmount = 0; rowAmount < _cellInLvlAmount / _cellInRowAmount; rowAmount++)
        {
            for (int cellInRowCounter = 0; cellInRowCounter < _cellInRowAmount; cellInRowCounter++)
            {
                var cell = Instantiate(_cell, new Vector2(_gridStartX, _gridStartY), Quaternion.identity);
                var cellContent = cell.transform.GetChild(0).GetComponent<SpriteRenderer>();
                cellContent.sprite = _bundleAndGoal.CurrentBundle[cellNum].Sprite;
                cell.GetComponent<Cell>().Initialisation(_bundleAndGoal.CurrentBundle[cellNum].Identifier, _bundleAndGoal.CurrentGoal.Identifier);
                _gridStartX += 1.5f;
                cellNum++;
            }
            _gridStartY -= 1.5f;
            _gridStartX = -1.5f;
        }
    }
}
