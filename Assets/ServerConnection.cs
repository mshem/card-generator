using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using UnityEngine;
using UnityEngine.Networking;

public class ServerConnection : MonoBehaviour
{
    private string server_url = "https://card-db-server.herokuapp.com/cards/json";
    
    IEnumerator GetCards()
    {
        UnityWebRequest request = UnityWebRequest.Get(server_url);
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {
            string text = "{\"cards\" : " + request.downloadHandler.text + "}";
            Debug.Log( text );

            string escapedText = HttpUtility.JavaScriptStringEncode(text, false);
            Debug.Log("escaped: " + escapedText);

            CardMasterList list = JsonUtility.FromJson<CardMasterList>(text);
            FindObjectOfType<CardList>().PopulateFromList(list);
            Debug.Log(list.cards);
        }
    }

    void Start()
    {
        StartCoroutine(GetCards());
    }
}
