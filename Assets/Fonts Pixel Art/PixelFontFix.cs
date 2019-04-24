using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelFontFix : MonoBehaviour
{
    public Font[] fonts;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
            Debug.Log("Fuente pixelada");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
