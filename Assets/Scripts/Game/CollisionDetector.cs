using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class CollisionDetector : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision!");
        other.GetComponent<CubeInBandMovement>().enabled = false;
        CubeToCanvasMovement cube = other.GetComponent<CubeToCanvasMovement>();
        cube.statement = true;
        cube.place = gameManager.CurrentCube;
    }
}
