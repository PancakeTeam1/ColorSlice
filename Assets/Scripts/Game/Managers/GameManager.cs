﻿using System.Collections;
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
        gridController = GridController.Instance;
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void Start()
    {
        CurrentCube = gridController.Cubes[0, 0].transform.position;
    }

    public void SetBandMode(Vector2Int CubeInCanvas)
    {
        cam.ViewSwitch = false;
        gridController.GetColorsInRow(CubeInCanvas.x, out colors);
        CurrentCube = gridController.Cubes[CubeInCanvas.x, CubeInCanvas.y].transform.position;
        StartCoroutine(bandGenerator.StartGeneration(colors));
    }

    
}
