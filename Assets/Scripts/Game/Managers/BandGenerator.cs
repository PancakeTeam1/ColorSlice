using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandGenerator : Manager<BandGenerator>
{
    public GameObject PrefabCube;
    public float Distance;
    public Color[] Colors;

    [HideInInspector]
    public Vector3 startPoint;
    [HideInInspector]
    public Vector3 endPoint;
    private Vector3 lastCubePos;
    private GameObject lastCube;
    private float currentDistance;

    private Pooler pooler;
    private GameManager gameManager;
    private ColorIndicator colorIndicator;
    //private InGameImageLoader imageLoader;

    private void Awake()
    {
        startPoint = transform.Find("StartPoint").position;
        endPoint = transform.Find("EndPoint").position;
    }

    private void Start()
    {
        pooler = Pooler.instance;
        gameManager = GameManager.Instance;
        //imageLoader = InGameImageLoader.Instance;
        //GetColorsFromImage();
    }

    public IEnumerator StartGeneration(Color[] colors)
    {
        while (true)
        {
            if (lastCube == null || currentDistance >= Distance)
            {
                lastCube = pooler.SpawnFromPull(PrefabCube, startPoint, transform);
                lastCube.GetComponent<Renderer>().materials[0].color = Colors[Random.Range(0, Colors.Length)];
                currentDistance = 0;
                lastCubePos = startPoint;
            }
            else
            {
                currentDistance += (lastCube.transform.position - lastCubePos).magnitude;
            }
            yield return null;
        }
    }

    /*private void GetColorsFromImage()
    {
        imageLoader.CreatePicture(0);
        Colors = imageLoader.GetAllColors().ToArray();
    }*/
}
