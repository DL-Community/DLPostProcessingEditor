using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSceneController : MonoBehaviour
{
    #region Preview Camera
    public Vector3[] previewPostions;
    public Camera previewCamera;
    public Transform PreviewCameraTransform => previewCamera?.transform;
    public Color PreviewCameraBackgroundColor => previewCamera.backgroundColor;
    int CurrentPostionSelection { get; set; }
    void InitPrevCamera()
    {

    }
    void UpdateCamPosition()
    {
        if(PreviewCameraTransform.localPosition != previewPostions[CurrentPostionSelection])
            PreviewCameraTransform.Translate((previewPostions[CurrentPostionSelection]- PreviewCameraTransform.localPosition) * 10f *Time.deltaTime,Space.Self);
    }




    public void ChangeCamPos(int value)
    {
        CurrentPostionSelection += value;
        if(CurrentPostionSelection >= previewPostions.Length)
            CurrentPostionSelection = 0;
        else if(CurrentPostionSelection < 0)
            CurrentPostionSelection = previewPostions.Length - 1;
    }
    #endregion




    void Update()
    {
        UpdateCamPosition();
    }
    private void Start()
    {
        InitPrevCamera();
    }
}
