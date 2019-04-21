using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PixelPerfectCamera : MonoBehaviour
{
    #region Pixel Perfect
    public int w = 720;
    private int h;
    public Camera cam;
    #endregion

    #region Set Screen Size
    public Vector2 aspectRatio = new Vector2(16, 9);
    public int scale = 2;
    private bool fullScreen = false;
    #endregion

    protected void Start()
    {
        #region Pixel Perfect
        cam = GetComponent<Camera>();

        //set the size based on the aspect ratio
        //Not neccesary, it needs to be puted in the camera settings
        //cam.orthographicSize = w*aspectRatio.y/aspectRatio.x;
        //------------------------------------------------------
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }
        #endregion

        #region Set Screen Size
        SetDefaultScreenSettings();
        setDefaultScreenSettings = false;
        //if 1, the game has not open before
        if (PlayerPrefs.GetInt("firstOpen") != 1)
        {
            PlayerPrefs.SetInt("fullScreen", 0);
            PlayerPrefs.SetInt("scale", scale);
            PlayerPrefs.SetInt("firstOpen", 1);
        }
        if (PlayerPrefs.GetInt("fullScreen") == 1)
        {
            fullScreen = true;
        }
        else
        {
            fullScreen = false;
        }
        //Set the screen resolution as wide define above * scale and size of the camera x scale //Size is *2 cause in camera is /2
        Screen.SetResolution(w * PlayerPrefs.GetInt("scale"), (int)cam.orthographicSize * 2 * PlayerPrefs.GetInt("scale"), fullScreen);
        #endregion
    }
    void Update()
    {
        #region Pixel Perfect
        float ratio = ((float)cam.pixelHeight / (float)cam.pixelWidth);
        h = Mathf.RoundToInt(w * ratio);
        #endregion

        #region Set Screen Size
        FullScreenDetect();
        Scale();
        #endregion
    }

    #region Pixel Perfect
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        source.filterMode = FilterMode.Point;
        RenderTexture buffer = RenderTexture.GetTemporary(w, h, -1);
        buffer.filterMode = FilterMode.Point;
        Graphics.Blit(source, buffer);
        Graphics.Blit(buffer, destination);
        RenderTexture.ReleaseTemporary(buffer);
    }
    #endregion

    #region Set Screen Size
    public bool scaleEditMode = true;
    private void Scale()
    {
        if (scaleEditMode)
        {
            if (Input.GetKeyDown("g"))
            {
                PlayerPrefs.SetInt("scale", PlayerPrefs.GetInt("scale") + 1);
                Start();
            }
            if (Input.GetKeyDown("h"))
            {
                PlayerPrefs.SetInt("scale", PlayerPrefs.GetInt("scale") - 1);
                Start();
            }
            if (Input.GetKeyDown("j"))
            {
                if (PlayerPrefs.GetInt("fullScreen") == 0)
                {
                    PlayerPrefs.SetInt("fullScreen", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("fullScreen", 0);
                }
                FullScreenDetect();
                Start();
            }
        }
    }

    private void FullScreenDetect()
    {
        if (PlayerPrefs.GetInt("fullScreen") == 1)
        {
            fullScreen = true;
        }
        else
        {
            fullScreen = false;
        }
    }

    public bool setDefaultScreenSettings = true;
    public void SetDefaultScreenSettings()
    {
        if (setDefaultScreenSettings)
        {
            PlayerPrefs.SetInt("firstOpen", 0);
            PlayerPrefs.SetInt("fullScreen", 0);
            PlayerPrefs.SetInt("scale", scale);
        }
    }
    #endregion
}
