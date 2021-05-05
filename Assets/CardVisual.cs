using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour
{
    private string cardName;
    
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI type;
    [SerializeField] private TextMeshProUGUI effectsDescription;
    [SerializeField] private TextMeshProUGUI flavorText;
    [SerializeField] private TextMeshProUGUI yield;
    [SerializeField] private TextMeshProUGUI turns;
    [SerializeField] private TextMeshProUGUI cost;

    [SerializeField] private Image cardImage;

    public CardData data;

    void Update()
    {
        if (title.text != data.title)
        {
            UpdateTitle(data.title);
        }
        if (type.text != data.card_type)
        {
            UpdateType(data.card_type);
        }
        if (effectsDescription.text != data.effects)
        {
            UpdateEffects(data.effects);
        }
        if (flavorText.text != data.flavor_text)
        {
            UpdateFlavorText(data.flavor_text);
        }
        if (yield.text != data.yield)
        {
            UpdateYield(data.yield);
        }
        if (turns.text != data.turns)
        {
            UpdateTurns(data.turns);
        }
        if (cost.text != data.cost)
        {
            UpdateCost(data.cost);
        }
    }

    public void UpdateLabels()
    {
        UpdateTitle(data.title);
        UpdateType(data.card_type);
        UpdateEffects(data.effects);
        UpdateFlavorText(data.flavor_text);
        UpdateYield(data.yield);
        UpdateTurns(data.turns);
        UpdateCost(data.cost);
        UpdateImage(data.card_image);
    }

    void UpdateTitle(string text)
    {
        title.text = text;
    }
    void UpdateType(string text)
    {
        type.text = text;
    }
    void UpdateEffects(string text)
    {
        effectsDescription.text = text;
    }
    void UpdateFlavorText(string text)
    {
        flavorText.text = text;
    }
    void UpdateYield(string text)
    {
        yield.text = text;
    }
    void UpdateTurns(string text)
    {
        turns.text = text;
    }
    void UpdateCost(string text)
    {
        cost.text = text;
    }

    void UpdateImage(string url)
    {
        StartCoroutine(DownloadImage(url));
    }
    IEnumerator DownloadImage(string url)
    {   
        float width = cardImage.transform.GetComponent<RectTransform>().rect.width;
        float height = cardImage.transform.GetComponent<RectTransform>().rect.height;
        Debug.Log("width: " + width + ", height: " + height);
        WWW www = new WWW (url);
        yield return www;
        if (www.error != null || www.bytes.Length == 0) {
            Debug.Log ("No remote image");
        } else {
            byte[] fileData = www.bytes;
            Texture2D tex = www.texture;
            // Texture2D tex = new Texture2D ((int)t.width,(int) t.height);
            // tex.LoadImage (fileData);
//		tex.Resize (width, height);
            Rect rect = cardImage.sprite.rect;
            rect.height = tex.height;
            rect.width = tex.width;
            Sprite s = Sprite.Create (tex, rect, cardImage.sprite.pivot);
            cardImage.sprite = s;
        }    
    } 
}
