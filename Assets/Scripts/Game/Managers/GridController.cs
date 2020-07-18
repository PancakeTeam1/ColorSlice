using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;



public class GridController : Manager<GridController>
{
    public Texture2D tex;
    public GameObject ObjectToSpawn;
    public int ArtWidth;
    public int ArtHeight;
    public float ArtpixelOffset;
    [HideInInspector] public float scaleValue;
    [HideInInspector] public GameObject[,] Cubes;
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
        Cubes = new GameObject[ArtWidth, ArtHeight];
        cam = Camera.main.GetComponent<CameraController>();
        SpawnGrid();
        SetPicture();
    }

    void SpawnGrid()
    {
        for (int x = 0; x < ArtWidth; x++)
        {
            for (int z = 0; z < ArtHeight; z++)
            {
                Vector3 spawnPosition = new Vector3(x * ArtpixelOffset, 0, z * ArtpixelOffset) + GridOrigin;
                Cubes[x, z] = Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
            }
        }

        camXOffset = ArtWidth / 2 - 0.5f + (ArtWidth - 1) * (ArtpixelOffset - 1) / 2 + GridOrigin.x;
        camYOffset = ArtWidth / 0.5f + GridOrigin.y;
        camZOffset = (ArtHeight / 2 + GridOrigin.z) * 0.5f;
        CamOffset = new Vector3(camXOffset, camYOffset, camZOffset);
        CenterCube = Vector3.Lerp(Cubes[ArtWidth - 1, ArtHeight - 1].transform.position, Cubes[0, 0].transform.position, 0.5f);
    }

    private void SetPicture()
    {
        Color[,] colors = AnalysePixel.Analyse(tex, 23, 28, 8, 7, 4, 4);
        for (int i = 0; i < ArtWidth; i++)
            for (int j = 0; j < ArtHeight; j++)
            {
                Cubes[i, j].gameObject.GetComponent<Renderer>().materials[0].color = colors[i, j];
            }
    }
}


