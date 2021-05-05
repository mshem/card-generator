using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;

    [SerializeField] private GameObject contentView;
    
    public void PopulateFromList(CardMasterList list)
    {
        foreach (var card in list.cards)
        {
            GameObject cardObject = Instantiate(cardPrefab);
            cardObject.GetComponent<Card>().data = card;
            cardObject.transform.SetParent(contentView.transform);
        }
    }

}
