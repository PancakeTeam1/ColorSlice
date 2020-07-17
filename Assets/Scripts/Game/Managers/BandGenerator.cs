using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandGenerator : MonoBehaviour
{
    public GameObject PrefabCube;
    public float distance;

    [HideInInspector]
    public Vector3 startPoint;
    [HideInInspector]
    public Vector3 endPoint;
    private Vector3 lastCubePos;
    private GameObject lastCube;
    private float currentDistance;
    private float localScale;

    private Pooler pooler;
    private GameManager gameManager;

    private void Awake()
    {
        startPoint = transform.Find("StartPoint").position;
        endPoint = transform.Find("EndPoint").position;    }

    private void Start()
    {
        pooler = Pooler.instance;
        gameManager = GameManager.Instance;
        localScale = gameManager.scaleValue;
    }

    private void Update()
    {
        if (lastCube == null || currentDistance >= distance)
        {
            lastCube = pooler.SpawnFromPull(PrefabCube, startPoint, transform);
            lastCube.transform.localScale = new Vector3(localScale, localScale, localScale);
            currentDistance = 0;
            lastCubePos = startPoint;
        }
        else
        {
            currentDistance += (lastCube.transform.position - lastCubePos).magnitude;
        }
    }
}
