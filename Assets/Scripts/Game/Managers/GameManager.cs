using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 SetCurrentCube;
    public GridController GridController;
    [HideInInspector] public Vector3 CurrentCube;
    [HideInInspector] public float CurrentCubeX;
    [HideInInspector] public float CurrentCubeZ;

    private void Update()
    {
        CurrentCube = GetCurrentCubePosition();
    }

    public Vector3 GetCurrentCubePosition()
    { 
        CurrentCubeX = GridController.CubeCoordinates[(int) SetCurrentCube.x, (int) SetCurrentCube.z, 0];
        CurrentCubeZ = GridController.CubeCoordinates[(int) SetCurrentCube.x, (int) SetCurrentCube.z, 1];
        return new Vector3(CurrentCubeX, 0, CurrentCubeZ);
    }
}
