using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    [HideInInspector] public CubeInCanvas CurrentCube;
    [HideInInspector] public int CubesPainted;
    [HideInInspector] public bool IsHitbutton = false;
    
    public float MissDelay = 1f;
    public GameObject HitButton;

    private GridController gridController;
    private CameraController cam;
    private BandGenerator bandGenerator;
    private CoinsManager coinsManager;
    private AudioController audioController;

    private Color[] colors;
    [HideInInspector] public Mode ModeCondition;
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
        audioController = AudioController.Instance;
        coinsManager = CoinsManager.Instance;
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
        CubesPainted += 1;
        if (frameCondition == Frame.Horizontal)
        {
            Vector2Int posCube = CurrentCube.PosInCanvas;

            if (posCube.x != gridController.ArtWidth - 1)
            {
                CurrentCube = gridController.Cubes[posCube.x + 1, posCube.y];
            }
            else  // if the row ends
            {
                if(posCube.y == 0 && posCube.x == gridController.ArtWidth - 1)  // if it was right bottom cube
                {
                    if(CubesPainted == gridController.SquareOfArt)  // if the art if completly painted over 
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
                    }
                    else
                    {
                        CurrentCube = gridController.Cubes[0, gridController.ArtHeight - 1];  // Set CurrebtCube to start position
                    }
                }
                else
                {
                    CurrentCube = gridController.Cubes[0, posCube.y - 1];  // set CurrentCube to the next row
                }
            }
        }
        else
        {
            Vector2Int posCube = CurrentCube.PosInCanvas;
            if (posCube.y != gridController.ArtHeight - 1)
                CurrentCube = gridController.Cubes[posCube.x, posCube.y + 1];
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

    public void CubeToCanvas(CubeInBandMovement other)
    {
        if (IsHitbutton)
        {
            IsHitbutton = false;
            Color colOther = other.mat.color;
            Color colCur = CurrentCube.mat.color;
            other.enabled = false;
            CubeToCanvasMovement cube = other.GetComponent<CubeToCanvasMovement>();
            GameObject particle = cube.transform.GetChild(0).gameObject;
            particle.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.color = colCur;
            particle.SetActive(true);
            //cube.GetComponentInChildren<ParticleSystem>().gameObject.SetActive(true);
            if (colOther.r == colCur.r && colOther.g == colCur.g && colOther.b == colCur.b)
            {
                audioController.PlayRighSound();
                cube.statement = true;
                cube.place = CurrentCube;
                coinsManager.AddCoins(5);
                coinsManager.AddCubeToStreak();
                SetNextCube();
            }
            else
            {
                audioController.PlayWrongSound();
                coinsManager.ClearStreak();
                StartCoroutine(MissCoolDown());
                cube.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator MissCoolDown()
    {
        HitButton.SetActive(false);
        yield return new WaitForSeconds(MissDelay);
        HitButton.SetActive(true);
    }
}
