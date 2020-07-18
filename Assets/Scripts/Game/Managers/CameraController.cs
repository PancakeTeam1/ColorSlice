using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed = 1.5f;
    public float offsetZ = 0.5f;
    public float offsetX = 1;
    public bool ViewSwitch = true;
    public int LengthAreaX = 6;
    private float averageY;
    public Vector3 defaultPos;
    private GameManager gameManager;
    private GridController gridController;

    private void Start()
    {
        gameManager = GameManager.Instance;
        gridController = GridController.Instance;
    }

    private void Update()
    {
        if (ViewSwitch)
            WatchOnArt();
        else
            WatchOnArtpixel();
    }
    public void WatchOnArtpixel()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(Mathf.Lerp(gameManager.CurrentCube.x, gridController.CenterCube.x, 2 * offsetX / gridController.ArtWidth), defaultPos.y, offsetZ), Time.deltaTime * Speed);
    }
    public void WatchOnArt()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, gridController.CamOffset, Time.deltaTime * Speed);
    }
}
