using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour
{
    private GameManager gameManager;
    private CameraController cameraController;
    
    public GameObject bandGenerator;
    public GameObject smallHammer;
    public GameObject hitButton;

    void Start()
    {
        cameraController = CameraController.Instance;
        gameManager = GameManager.Instance;
    }

    public void SwitchCameraView()
    {
        gameManager.ModeCondition = GameManager.Mode.Canvas;
        cameraController.ViewSwitch = !cameraController.ViewSwitch;

        // activate or deactivate all HUD
        bandGenerator.SetActive(!bandGenerator.activeSelf);
        smallHammer.SetActive(!smallHammer.activeSelf);
        hitButton.SetActive(!hitButton.activeSelf);
    }
}
