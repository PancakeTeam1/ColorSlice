using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandGenerator : MonoBehaviour
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

    private void Awake()
    {
        startPoint = transform.Find("StartPoint").position;
        endPoint = transform.Find("EndPoint").position;
    }

    private void Start()
    {
        pooler = Pooler.instance;
        gameManager = GameManager.Instance;
    }

    private void Update()
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
    }
}
