using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed = 0f;
    private float r;

    [HideInInspector]
    public Vector3 defaultPos;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(gameManager.currentCube.x, 0f, gameManager.currentCube.z) - new Vector3(transform.position.x, 0f, transform.position.z);
        r = Vector3.SqrMagnitude(direction);
        if (r < 0.02)
        {
            transform.position += direction * 0.1f;
        }
        else
        {
            speed = (r + 2) / 100;
            Debug.Log(direction.normalized * speed);
            transform.Translate(direction.normalized * speed, Space.World);
        }
    }

}
