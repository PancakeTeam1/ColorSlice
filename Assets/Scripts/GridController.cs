using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public int ArtWidth;
    public int ArtHeight;
    public float ArtpixelOffset;
    [HideInInspector] public float scaleValue;
    [HideInInspector] public Vector3[,] CubeCoordinates;
    [HideInInspector] public Vector3 CenterCube;
    public Vector3 GridOrigin = new Vector3(0, 0, 0);

    public static GridController instance;

    private CameraController cam;

    private void Awake()
    {
        instance = this;
        CubeCoordinates = new Vector3[ArtWidth, ArtHeight];
        cam = Camera.main.GetComponent<CameraController>();
        SpawnGrid();
    }

    void Scale()
    {
        float x = cam.transform.position.y * 0.58f;
        scaleValue = x / ((ArtWidth + (ArtWidth - 2) * (ArtpixelOffset - 1)) / 2);
    }

    void SpawnGrid()
    {
        Scale();
        float scale = scaleValue * 0.5f;
        for (int x = 0; x < ArtWidth; x++)
        {
            for (int z = 0; z < ArtHeight; z++)
            {
                Vector3 spawnPosition = new Vector3(x * ArtpixelOffset * scale, 0, z * ArtpixelOffset * scale) + GridOrigin;
                GameObject clone = Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
                clone.transform.localScale = new Vector3(scale, scale, scale);
                CubeCoordinates[x, z] = spawnPosition;
            }
        }
        CenterCube = (CubeCoordinates[ArtHeight - 1, ArtWidth - 1] - CubeCoordinates[0, 0]) * 0.5f;
        float currentSizeX = (ArtWidth - 1 + (ArtWidth - 1) * (ArtpixelOffset - 1)) * scale / 2;
        cam.defaultPos = cam.transform.position + new Vector3(currentSizeX, 0, 0);
        cam.transform.position = cam.defaultPos;
    }
}
