using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public float ArtWidth, ArtHeight;
    public float ArtpixelOffset;
    [HideInInspector] public float scaleValue;
    public Vector3 GridOrigin = new Vector3(0, 0, 0);

    private CameraController cam;
    private GameManager gameManager;

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    void Start()
    {
        gameManager = GameManager.instance;
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
                if (z == 0 && x == 0)
                    gameManager.currentCube = spawnPosition;
                GameObject clone = Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
                clone.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
        float currentSizeX = (ArtWidth - 1 + (ArtWidth - 1) * (ArtpixelOffset - 1)) * scale / 2;
        cam.defaultPos = cam.transform.position + new Vector3(currentSizeX, 0, 0);
        cam.transform.position = cam.defaultPos;
    }
}
