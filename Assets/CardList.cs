using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    [SerializeField]
    private GameObject plantCardPrefab;
    
    [SerializeField]
    private GameObject substrateCardPrefab;
    
    [SerializeField]
    private GameObject lifeCardPrefab;    
    [SerializeField]
    private GameObject materialCardPrefab;    
    [SerializeField]
    private GameObject toolCardPrefab;

    [SerializeField] private GameObject contentView;
    
    public void PopulateFromList(CardMasterList list)
    {
        foreach (var card in list.cards)
        {
            GameObject cardObject;
            if (card.card_type.ToLower().Contains("substrate"))
            {
                cardObject = Instantiate(substrateCardPrefab);
            }
            else if (card.card_type.ToLower().Contains("tool"))
            {
                cardObject = Instantiate(toolCardPrefab);
            }
            else if (card.card_type.ToLower().Contains("life"))
            {
                cardObject = Instantiate(lifeCardPrefab);
            }
            else if (card.card_type.ToLower().Contains("material"))
            {
                cardObject = Instantiate(materialCardPrefab);
            }else
            {
                cardObject = Instantiate(plantCardPrefab);
            }
            cardObject.GetComponent<Card>().data = card;
            cardObject.transform.SetParent(contentView.transform);
        }
    }

}
