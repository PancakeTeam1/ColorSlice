using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandGenerator : Manager<BandGenerator>
{
    public GameObject PrefabCube;
    public float Distance;
    private Color[] colors;

    [HideInInspector]
    public Transform startPoint;
    [HideInInspector]
    public Transform endPoint;
    //[HideInInspector] public bool isDeactivated = false;
    private Vector3 lastCubePos;
    private GameObject lastCube;
    private float currentDistance;

    private Pooler pooler;
    private GameManager gameManager;
    private ColorIndicator colorIndicator;
    //private InGameImageLoader imageLoader;

    private void Awake()
    {
        startPoint = transform.Find("StartPoint");
        endPoint = transform.Find("EndPoint");
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
        yield return new WaitForSeconds(1);
        this.colors = GridController.MakeSet<Color>(colors);
        colors = this.colors;
        while (true)
        {
            if (lastCube == null || currentDistance >= Distance)
            {
                //isDeactivated = false;
                lastCube = pooler.SpawnFromPull(PrefabCube, startPoint.position, transform);
                GameObject particle = lastCube.transform.GetChild(0).gameObject;
                particle.SetActive(false);
                lastCube.GetComponent<CubeToCanvasMovement>().statement = false;
                lastCube.GetComponent<CubeInBandMovement>().enabled = true;
                lastCube.GetComponent<Renderer>().materials[0].color = colors[Random.Range(0, colors.Length)];
                currentDistance = 0;
                lastCubePos = startPoint.localPosition;
            }
            else
            {
                currentDistance += (lastCube.transform.localPosition - lastCubePos).magnitude;
                lastCubePos = lastCube.transform.localPosition;
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
