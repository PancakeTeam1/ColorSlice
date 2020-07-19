using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeToCanvasMovement : MonoBehaviour
{
    private bool ShouldMoveToPosition = false;

    public float Speed = 1f;
    public bool statement;  // when should we move our cube to place
    public Vector3 place;  // place, where should we move our cube

    private GameManager gameManager;
    private BandGenerator bandGenerator;

    private void Start()
    {
        gameManager = GameManager.Instance;
        bandGenerator = BandGenerator.Instance;
    }

    private void Update()
    {
        if (statement)
        {
            ShouldMoveToPosition = true;
        }

        if (ShouldMoveToPosition)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, place, Time.deltaTime * Speed);
        }

        if (Vector3.Distance(this.transform.position, place) < 0.05f && ShouldMoveToPosition)
        {
            Debug.Log("should move");
            ShouldMoveToPosition = false;
            this.gameObject.SetActive(false);
            bandGenerator.isDeactivated = true;
        }
    }

    public void ShouldCubeMove(bool condition)
    {
        ShouldMoveToPosition = condition;
    }
}
