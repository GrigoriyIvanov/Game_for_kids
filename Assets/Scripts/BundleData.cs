using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New BundleData", menuName = "Boundle Data")]
public class BundleData : ScriptableObject
{
    [SerializeField] private CardData[] _cardData;
    public CardData[] CardData => _cardData;
}
