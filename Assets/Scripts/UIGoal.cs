using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGoal : MonoBehaviour
{
    [SerializeField] private BundleAndGoalPeacker _bundleAndGoal;
    private void Start()
    {
        BundleAndGoalPeacker.OnGoalPicked += OnGoalPicked;
    }
    private void OnGoalPicked()
    {
        gameObject.GetComponent<Text>().text = _bundleAndGoal.CurrentGoal.Identifier;
    }
}
