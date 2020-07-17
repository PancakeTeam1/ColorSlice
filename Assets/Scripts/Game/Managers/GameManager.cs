using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    public Vector3 CurrentCube;
    private GridController gridController;
    public float scaleValue;

    private void Start()
    {
        gridController = GridController.Instance;
        CurrentCube = gridController.CubeCoordinates[0, 0];
    }
}
