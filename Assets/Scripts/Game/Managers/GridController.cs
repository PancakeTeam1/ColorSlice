using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject ObjectToSpawn;
<<<<<<< Updated upstream:Assets/Scripts/GridController.cs
    public float ArtWidth;
    public float ArtHeight;
    public float ArtpixelOffset;
    [HideInInspector] public float scaleValue;
    [HideInInspector] public float[,,] CubeCoordinates;
=======
<<<<<<< HEAD:Assets/Scripts/GridController.cs
    public int ArtWidth;
    public int ArtHeight;
    public float ArtpixelOffset;
    [HideInInspector] public float scaleValue;
    [HideInInspector] public Vector3[,] CubeCoordinates;
    [HideInInspector] public Vector3 CenterCube;
=======
    public float ArtWidth;
    public float ArtHeight;
    public float ArtpixelOffset;
    [HideInInspector] public float scaleValue;
    [HideInInspector] public float[,,] CubeCoordinates;
>>>>>>> master:Assets/Scripts/Game/Managers/GridController.cs
>>>>>>> Stashed changes:Assets/Scripts/Game/Managers/GridController.cs
    public Vector3 GridOrigin = new Vector3(0, 0, 0);

    private CameraController cam;

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
<<<<<<< Updated upstream:Assets/Scripts/GridController.cs
=======
<<<<<<< HEAD:Assets/Scripts/GridController.cs
=======
>>>>>>> Stashed changes:Assets/Scripts/Game/Managers/GridController.cs
    }

    void Start()
    {
        CubeCoordinates = new float[(int) ArtWidth, (int) ArtHeight, 2];
<<<<<<< Updated upstream:Assets/Scripts/GridController.cs
=======
>>>>>>> master:Assets/Scripts/Game/Managers/GridController.cs
>>>>>>> Stashed changes:Assets/Scripts/Game/Managers/GridController.cs
        SpawnGrid();
        //float camXOffset = ArtWidth / 2 + (ArtWidth - 2) * (ArtpixelOffset - 1) / 2 + GridOrigin.x;
        //float camYOffset = ArtWidth / 0.58f + GridOrigin.y; 
        //float camZOffset = (ArtHeight / 2 + GridOrigin.z) * 0.5f;
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
<<<<<<< Updated upstream:Assets/Scripts/GridController.cs
                CubeCoordinates[x, z, 0] = spawnPosition.x;
                CubeCoordinates[x, z, 1] = spawnPosition.z;
=======
<<<<<<< HEAD:Assets/Scripts/GridController.cs
                CubeCoordinates[x, z] = spawnPosition;
=======
                CubeCoordinates[x, z, 0] = spawnPosition.x;
                CubeCoordinates[x, z, 1] = spawnPosition.z;
>>>>>>> master:Assets/Scripts/Game/Managers/GridController.cs
>>>>>>> Stashed changes:Assets/Scripts/Game/Managers/GridController.cs
            }
        }
        float currentSizeX = (ArtWidth - 1 + (ArtWidth - 1) * (ArtpixelOffset - 1)) * scale / 2;
        cam.defaultPos = cam.transform.position + new Vector3(currentSizeX, 0, 0);
        cam.transform.position = cam.defaultPos;
    }
}
