﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    public CubeInCanvas CurrentCube;
    private GridController gridController;
    private CameraController cam;
    private BandGenerator bandGenerator;
    private Color[] colors;
    [HideInInspector]
    public Mode ModeCondition;
    // показывает, какая рамка отображается на данный момент
    private Frame frameCondition = Frame.None;
    private FrameController frame;

    public enum Mode
    {
        Canvas,
        Band
    }

    public enum Frame
    {
        None,
        Horizontal,
        Vertical
    }

    private void Awake()
    {
        frame = FrameController.Instance;
        bandGenerator = BandGenerator.Instance;
        gridController = GridController.Instance;
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void Start()
    {
        ModeCondition = Mode.Canvas;
    }

    public void SetBandMode(Vector2Int CubeInCanvas)
    {
        if (ModeCondition != Mode.Band)
        {
            ModeCondition = Mode.Band;
            cam.ViewSwitch = false;
            gridController.GetColorsInRow(CubeInCanvas.y, out colors);
            CurrentCube = gridController.Cubes[CubeInCanvas.x, CubeInCanvas.y];
            StartCoroutine(bandGenerator.StartGeneration(colors));
        }
    }
    
    public void SetNextCube()
    {
        if (frameCondition == Frame.Horizontal)
        {
            Vector2Int posCube = CurrentCube.PosInCanvas;
            if (posCube.x != gridController.ArtWidth - 1)
                CurrentCube = gridController.Cubes[posCube.x + 1, posCube.y];
        }
    }

    public void PressCube(CubeInCanvas pressed)
    {
        if (CurrentCube == pressed)
        {
            if (frameCondition != Frame.Vertical)
                frameCondition = (Frame)((int)frameCondition + 1);
            else
                frameCondition = Frame.Horizontal;
            
        }
        else
        {
            CurrentCube = pressed;
            frameCondition = Frame.Horizontal;
        }
        frame.SetFrame(frameCondition, pressed.PosInCanvas);
    }

    public void OnClickStart()
    {
            SetBandMode(CurrentCube.PosInCanvas);
    }

    public void CubeToCanvas(Collider other)
    {
        Debug.Log("collision!");
        other.GetComponent<CubeInBandMovement>().enabled = false;
        CubeToCanvasMovement cube = other.GetComponent<CubeToCanvasMovement>();
        cube.statement = true;
        cube.place = CurrentCube.transform.position;
    }

    public void CanvasCubeActivation()
    {
        //set canvas cube alpha from ~0.2 to 1
    }
}
