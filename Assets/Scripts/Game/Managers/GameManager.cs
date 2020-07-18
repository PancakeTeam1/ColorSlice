using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    public Vector3 CurrentCube;
    private GridController gridController;

    private void Start()
    {
        gridController = GridController.Instance;
        CurrentCube = gridController.Cubes[0, 0].transform.position;
    }

    
}
