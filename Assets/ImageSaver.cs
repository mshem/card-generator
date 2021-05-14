using System.Collections;
using System.Drawing;
using System.IO;
using UnityEngine;

public class ImageSaver : MonoBehaviour 
{
    public RectTransform rectT; // Assign the UI element which you wanna capture
    int width; // width of the object to capture
    int height; // height of the object to capture
    public Canvas _canvas;
    
    public Camera printCam;
    private RenderTexture rendText;

// Update is called once per frame
    void Update () 
    {
        if (Input.GetKeyDown (KeyCode.A)) 
        {
            Vector3[] corners = new Vector3[4];
            rectT.GetWorldCorners(corners);
            Debug.Log(corners);
            width = System.Convert.ToInt32(Mathf.Abs(corners[0][0] - corners[2][0])); 
            height = System.Convert.ToInt32(Mathf.Abs(corners[0][1] - corners[1][1]));
            printCam.aspect = (float) width / height;
            rendText = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32);
            rendText.useDynamicScale = true;
            rendText.antiAliasing = 3;
            rendText.filterMode = FilterMode.Trilinear;
            rendText.useMipMap = true;
            printCam.targetTexture = rendText;
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = printCam;
            StartCoroutine(takeScreenShot ()); // screenshot of a particular UI Element.
        }

    }
    public IEnumerator takeScreenShot()
    {
        yield return new WaitForEndOfFrame (); 
        Texture2D tex2d = new Texture2D(rendText.width, rendText.height, TextureFormat.ARGB32, rendText.useMipMap);
        RenderTexture.active = rendText;
        tex2d.ReadPixels(new Rect(0, 0, rendText.width, rendText.height), 0, 0);
        tex2d.Apply();
        byte[] bytes = tex2d.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
        yield return new WaitForEndOfFrame (); 
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }
}