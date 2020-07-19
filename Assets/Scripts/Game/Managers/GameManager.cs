using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    public Vector3 CurrentCube;
    public GameObject BandGeneratorObject;
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
        StartCoroutine(startTimer());
    }

    IEnumerator startTimer()
    {
        for (int i = 3; i > 0; i--)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }
        BandGeneratorObject.SetActive(true);
    }  
    public void SetBandMode(int rowInCanvas)
    {
        cam.ViewSwitch = false;
        gridController.GetColorsInRow(rowInCanvas, out colors);
        StartCoroutine(bandGenerator.StartGeneration(colors));
    }   
}
