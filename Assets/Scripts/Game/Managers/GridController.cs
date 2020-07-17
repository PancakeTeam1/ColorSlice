using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class GridController : Manager<GridController>
{
    public GameObject ObjectToSpawn;
    public int ArtWidth;
    public int ArtHeight;
    public float ArtpixelOffset;
    [HideInInspector] public float scaleValue;
    [HideInInspector] public Vector3[,] CubeCoordinates;
    [HideInInspector] public Vector3 CenterCube;
    [HideInInspector] public Vector3 CamOffset;
    [HideInInspector] public float camXOffset;
    [HideInInspector] public float camYOffset;
    [HideInInspector] public float camZOffset;
    public Vector3 GridOrigin = new Vector3(0, 0, 0);

    private CameraController cam;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        CubeCoordinates = new Vector3[ArtWidth, ArtHeight];
        cam = Camera.main.GetComponent<CameraController>();
        SpawnGrid();
    }

    void SpawnGrid()
    {
        for (int x = 0; x < ArtWidth; x++)
        {
            for (int z = 0; z < ArtHeight; z++)
            {
                Vector3 spawnPosition = new Vector3(x * ArtpixelOffset, 0, z * ArtpixelOffset) + GridOrigin;
                Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
                CubeCoordinates[x, z] = spawnPosition;
            }
        }
        camXOffset = ArtWidth / 2 - 0.5f + (ArtWidth - 1) * (ArtpixelOffset - 1) / 2 + GridOrigin.x;
        camYOffset = ArtWidth / 0.5f + GridOrigin.y;
        camZOffset = (ArtHeight / 2 + GridOrigin.z) * 0.5f;
        CamOffset = new Vector3(camXOffset, camYOffset, camZOffset);
        CenterCube = (CubeCoordinates[ArtHeight - 1, ArtWidth - 1] - CubeCoordinates[0, 0]) * 0.5f;
    }
}


