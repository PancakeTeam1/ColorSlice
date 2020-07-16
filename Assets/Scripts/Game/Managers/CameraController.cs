using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Scripts/CameraController.cs
    public float Speed;
=======
<<<<<<< HEAD:Assets/Scripts/CameraController.cs
    public float Speed = 1.5f;
    public float offsetZ = 0.5f;
    public float offsetX = 1;
    public int LengthAreaX = 6;
    private float averageY;
=======
    public float Speed;

>>>>>>> master:Assets/Scripts/Game/Managers/CameraController.cs
    [HideInInspector] public Vector3 defaultPos;
    private GameManager gameManager;
    private GridController gridController;
>>>>>>> Stashed changes:Assets/Scripts/Game/Managers/CameraController.cs

    [HideInInspector] public Vector3 defaultPos;
    public GameManager gameManager;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
<<<<<<< Updated upstream:Assets/Scripts/CameraController.cs
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(gameManager.CurrentCube.x, this.transform.position.y, gameManager.CurrentCube.z), Time.deltaTime * Speed);
=======
<<<<<<< HEAD:Assets/Scripts/CameraController.cs
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(gameManager.CurrentCube.x, this.transform.position.y, gameManager.CurrentCube.z) + new Vector3(Mathf.Lerp(gameManager.CurrentCube.x, gridController.CenterCube.x, 2 * offsetX / gridController.ArtWidth), 0f, offsetZ), Time.deltaTime * Speed);
        // 
=======
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(gameManager.CurrentCube.x, this.transform.position.y, gameManager.CurrentCube.z), Time.deltaTime * Speed);
>>>>>>> master:Assets/Scripts/Game/Managers/CameraController.cs
>>>>>>> Stashed changes:Assets/Scripts/Game/Managers/CameraController.cs
    }
}
