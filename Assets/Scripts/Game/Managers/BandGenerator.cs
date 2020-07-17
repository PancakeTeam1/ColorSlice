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

    private Pooler pooler;
    private CubeInBandMovement cube;

    private void Awake()
    {
        startPoint = transform.Find("StartPoint").position;
        endPoint = transform.Find("EndPoint").position;
        cube = PrefabCube.GetComponent<CubeInBandMovement>();
        
    }

    private void Start()
    {
        pooler = Pooler.instance;
    }

    private void Update()
    {
        if (lastCube == null || currentDistance >= distance)
        {
            lastCube = pooler.SpawnFromPull(PrefabCube, startPoint, transform);
            currentDistance = 0;
            lastCubePos = startPoint;
        }
        else
        {
            currentDistance += (lastCube.transform.position - lastCubePos).magnitude;
        }
    }
}
