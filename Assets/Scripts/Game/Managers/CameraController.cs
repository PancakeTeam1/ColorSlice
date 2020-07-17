using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed = 1.5f;
    public float offsetZ = 0.5f;
    public float offsetX = 1;
    public int LengthAreaX = 6;
    private float averageY;
    [HideInInspector] public Vector3 defaultPos;
    private GameManager gameManager;
    private GridController gridController;

    private void Start()
    {
        gameManager = GameManager.Instance;
        gridController = GridController.Instance;
        this.transform.position += new Vector3(0f, -this.transform.position.y + Mathf.Lerp(gridController.CenterCube.y, this.transform.position.y, (float)LengthAreaX / gridController.ArtHeight), 0f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(Mathf.Lerp(gameManager.CurrentCube.x, gridController.CenterCube.x, 2 * offsetX / gridController.ArtWidth), transform.position.y, offsetZ), Time.deltaTime * Speed);
    }
}
