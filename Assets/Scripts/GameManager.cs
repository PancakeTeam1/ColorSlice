using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 CurrentCube;
    private GridController gridController;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gridController = GridController.instance;
        CurrentCube = gridController.CubeCoordinates[0, 0];
    }
}
