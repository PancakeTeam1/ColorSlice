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
    [HideInInspector] public CubeInCanvas[,] Cubes;
    [HideInInspector] public Material[,] CubesMaterial;
    [HideInInspector] public Vector3 CenterCube;
    [HideInInspector] public Vector3 CamOffset;
    [HideInInspector] public float camXOffset;
    [HideInInspector] public float camYOffset;
    [HideInInspector] public float camZOffset;
    public Vector3 GridOrigin = new Vector3(0, 0, 0);

    private CameraController cam;
    private GameManager gameManager;
    private InGameImageLoader imageLoader;

    private void Awake()
    {
        imageLoader = InGameImageLoader.Instance;
        gameManager = GameManager.Instance;
        Cubes = new CubeInCanvas[ArtWidth, ArtHeight];
        CubesMaterial = new Material[ArtWidth, ArtHeight];
        cam = Camera.main.GetComponent<CameraController>();
        SpawnGrid();
        SetPicture(0);
    }

    void SpawnGrid()
    {
        for (int x = 0; x < ArtWidth; x++)
        {
            for (int z = 0; z < ArtHeight; z++)
            {
                Vector3 spawnPosition = new Vector3(x * ArtpixelOffset, 0, z * ArtpixelOffset) + GridOrigin;
                Cubes[x, z] = Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity).GetComponent<CubeInCanvas>();
                Cubes[x, z].PosInCanvas = new Vector2Int(x, z);
                CubesMaterial[x, z] = Cubes[x, z].GetComponent<Renderer>().materials[0];
            }
        }
        camXOffset = ArtWidth / 2 - 0.5f + (ArtWidth - 1) * (ArtpixelOffset - 1) / 2 + GridOrigin.x;
        camYOffset = ArtWidth / 0.5f + GridOrigin.y;
        camZOffset = (ArtHeight / 2 + GridOrigin.z) * 0.5f;
        CamOffset = new Vector3(camXOffset, camYOffset, camZOffset);
        cam.defaultPos = CamOffset;
        CenterCube = Vector3.Lerp(Cubes[ArtWidth - 1, ArtHeight - 1].transform.position, Cubes[0, 0].transform.position, 0.5f);
    }

    private void SetPicture(int NumberPicture)
    {
        Color[,] colors = imageLoader.CreatePicture(NumberPicture);
        for (int i = 0; i < ArtWidth; i++)
            for (int j = 0; j < ArtHeight; j++)
            {
                Cubes[i, ArtHeight - j - 1].gameObject.GetComponent<Renderer>().materials[0].color = colors[i, j];
            }
    }

    public void GetColorsInRow(int row, out Color[] colors)
    {
        colors = new Color[ArtHeight];
        for (int i = 0; i < ArtHeight; i++)
        {
            colors[i] = CubesMaterial[row, i].color;
        }
    }

    public static T[] MakeSet<T>(T[] objects)
    {
        List<T> objs = new List<T>();
        for(int i = 0; i < objects.Length; i++)
        {
            if (!objs.Contains(objects[i]))
            {
                objs.Add(objects[i]);
            }
        }
        return objs.ToArray();
    } 
}


