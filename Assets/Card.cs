using System;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData data;
    public CardVisual visual;
    public GameObject prefab;

    private void Start()
    {
        visual.data = data;
        visual.UpdateLabels();
    }
}
