using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewSceneController : MonoBehaviour
{
    #region Preview Camera
    [Header("Preview Camera")]
    public PrevObjects[] prevObjects;
    [System.Serializable]
    public class PrevObjects
    {
        public Vector3 camPosition;
        public string prevObjectName;
    }
    public Text prevObjectName;
    public Camera previewCamera;
    public Transform PreviewCameraTransform => previewCamera?.transform;
    public Color PreviewCameraBackgroundColor => previewCamera.backgroundColor;
    int CurrentPostionSelection { get; set; }
    void InitPrevCamera()
    {

    }
    void UpdateCamPosition()
    {
        if(PreviewCameraTransform.localPosition != prevObjects[CurrentPostionSelection].camPosition)
            PreviewCameraTransform.Translate((prevObjects[CurrentPostionSelection].camPosition- PreviewCameraTransform.localPosition) * 10f *Time.deltaTime,Space.Self);
    }




    public void ChangeCamPos(int value)
    {
        CurrentPostionSelection += value;
        if (CurrentPostionSelection >= prevObjects.Length)
            CurrentPostionSelection = 0;
        else if(CurrentPostionSelection < 0)
            CurrentPostionSelection = prevObjects.Length - 1;
        prevObjectName.text = prevObjects[CurrentPostionSelection].prevObjectName;
    }
    #endregion

    #region Env
    [Header("ENV")]
    public Material cubeMat;
    public Material sphereMat;
    public Material capsuleMat;
    public Material planeMat;
    void InitEnv()
    {

    }

    public Color FogColor
    {
        get 
        {

            Color color =  PlayerPrefsEX.GetColor("FogColor", new Color(220, 249, 255, 0));
            RenderSettings.fogColor = color;
            return color;
        }
        set
        {
            RenderSettings.fogColor = value;

            PlayerPrefsEX.SetColor("FogColor", value);
        }
    }


    #endregion


    void Update()
    {
        UpdateCamPosition();
    }
    private void Start()
    {
        InitPrevCamera();
        InitEnv();
    }
}
