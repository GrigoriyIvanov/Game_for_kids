using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BundleAndGoalPeacker : MonoBehaviour
{
    [SerializeField] private List<BundleData> _bundles = new List<BundleData>();
    private List<List<CardData>> _allGoals = new List<List<CardData>>();
    private List<List<CardData>> _allCells = new List<List<CardData>>();

    private List<CardData> _currentBundle;
    private CardData _currentGoal;
    private int _currentBundleNumber;
    [SerializeField] LvlCellAmount CellAmount;

    public delegate void GoalPicked();
    public static event GoalPicked OnGoalPicked;

    public List<CardData> CurrentBundle => _currentBundle;
    public CardData CurrentGoal => _currentGoal;

    private void Start()
    {
        Cell.OnLevelPased += onLvlPased;
        for (int bundlesCounter = 0; bundlesCounter < _bundles.Count; bundlesCounter++)
        {
            _allGoals.Add(new List<CardData>());
            _allCells.Add(new List<CardData>());
            for (int cardsInBundleCounter = 0;
                cardsInBundleCounter < _bundles[bundlesCounter].CardData.Length; 
                cardsInBundleCounter++)
            {
                _allGoals[bundlesCounter].Add(_bundles[bundlesCounter].CardData[cardsInBundleCounter]);
                _allCells[bundlesCounter].Add(_bundles[bundlesCounter].CardData[cardsInBundleCounter]);
            }
        }

        PickBundle();
        PickGoal();
    }
    private void PickBundle()
    {
        _currentBundleNumber = Random.Range(0, _bundles.Count-1); // Не забыть исправить
        
        var allCells = new List<CardData>(_allCells[_currentBundleNumber]);

        for (int cellInBundle = allCells.Count; cellInBundle > CellAmount.CellInLvlAmount; cellInBundle--)
        {
            allCells.Remove(allCells[Random.Range(0, cellInBundle)]);
        }
        _currentBundle = new List<CardData>(allCells);
    }
    private void PickGoal()
    {
        var randomGoal = Random.Range(0, _currentBundle.Count);
        while (!_allGoals[_currentBundleNumber].Contains(_currentBundle[randomGoal]))
        {
            randomGoal = Random.Range(0, _currentBundle.Count);
        }
        _currentGoal = _currentBundle[randomGoal];
        _allGoals[_currentBundleNumber].Remove(_currentGoal);
        OnGoalPicked?.Invoke();
    }
    private void onLvlPased()
    {
        var cells = FindObjectsOfType<Cell>();
        foreach (Cell cell in cells)
        {
            Destroy(cell.gameObject);
        }
        PickBundle();
        PickGoal();
    }
}
