using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed;

    [HideInInspector] public Vector3 defaultPos;
    public GameManager gameManager;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(gameManager.CurrentCube.x, this.transform.position.y, gameManager.CurrentCube.z), Time.deltaTime * Speed);
    }
}
