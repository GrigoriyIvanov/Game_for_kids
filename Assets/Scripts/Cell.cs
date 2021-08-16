using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    private string _value;
    private string _goal;

    public delegate void LevelPased();
    public static event LevelPased OnLevelPased;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_value == _goal)
        {
            OnLevelPased?.Invoke();
        }
        else
        {
            Debug.Log("U are not right");
        }
    }
    public void Initialisation(string value, string goal)
    {
        _value = value;
        _goal = goal;
    }
}
