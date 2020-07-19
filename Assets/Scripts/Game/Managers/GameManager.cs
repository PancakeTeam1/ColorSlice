using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    public Vector3 CurrentCube;
    private GridController gridController;
    private CameraController cam;
    private BandGenerator bandGenerator;
    private Color[] colors;

    private void Awake()
    {
        bandGenerator = BandGenerator.Instance;
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void Start()
    {
        gridController = GridController.Instance;
        CurrentCube = gridController.Cubes[0, 0].transform.position;
    }

    public void SetBandMode(int rowInCanvas)
    {
        cam.ViewSwitch = false;
        gridController.GetColorsInRow(rowInCanvas, out colors);
        StartCoroutine(bandGenerator.StartGeneration(colors));
    }   
}
