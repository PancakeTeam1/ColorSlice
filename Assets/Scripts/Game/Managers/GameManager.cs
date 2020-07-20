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
    private CubeInCanvas pressedCube;
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
        CurrentCube = gridController.Cubes[0, 0].transform.position;
    }

    public void SetBandMode(Vector2Int CubeInCanvas)
    {
        if (ModeCondition != Mode.Band)
        {
            ModeCondition = Mode.Band;
            cam.ViewSwitch = false;
            gridController.GetColorsInRow(CubeInCanvas.y, out colors);
            CurrentCube = gridController.Cubes[CubeInCanvas.x, CubeInCanvas.y].transform.position;
            StartCoroutine(bandGenerator.StartGeneration(colors));
        }
    }
    
    public void PressCube(CubeInCanvas pressed)
    {
        if (pressed == pressedCube)
        {
            if (frameCondition != Frame.Vertical)
                frameCondition = (Frame)((int)frameCondition + 1);
            else
                frameCondition = Frame.Horizontal;
            
        }
        else
        {
            pressedCube = pressed;
            frameCondition = Frame.Horizontal;
        }
        frame.SetFrame(frameCondition, pressed.PosInCanvas);
    }

    public void OnClickStart()
    {
            SetBandMode(pressedCube.PosInCanvas);
    }

    public void CubeToCanvas(Collider other)
    {
        Debug.Log("collision!");
        other.GetComponent<CubeInBandMovement>().enabled = false;
        CubeToCanvasMovement cube = other.GetComponent<CubeToCanvasMovement>();
        cube.statement = true;
        cube.place = CurrentCube;
    }

    public void CanvasCubeActivation()
    {
        //set canvas cube alpha from ~0.2 to 1
    }
}
