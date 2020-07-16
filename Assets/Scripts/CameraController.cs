using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed = 0f;
    private float r;

    [HideInInspector] public Vector3 defaultPos;
    public GameManager gameManager;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(gameManager.currentCube.x, 0f, gameManager.currentCube.z) - new Vector3(this.transform.position.x, 0f, this.transform.position.z);
        r = Vector3.SqrMagnitude(direction);
        speed = (r) / 100 + 0.01f;
        //Debug.Log(direction.normalized * speed * Time.deltaTime);
        transform.Translate(direction.normalized * speed, Space.World);
    }
}
