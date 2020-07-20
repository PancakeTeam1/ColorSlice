using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CubeToCanvasMovement : MonoBehaviour
{
    private bool ShouldMoveToPosition = false;

    public float Speed = 5f;
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
            transform.Translate((place - this.transform.position).normalized * Speed * Time.deltaTime);
        }

        if (Vector3.Distance(this.transform.position, place) < 0.05f && ShouldMoveToPosition)
        {
            ShouldMoveToPosition = false;
            this.gameObject.SetActive(false);
            gameManager.CurrentCube.PutCubeBand();
            //bandGenerator.isDeactivated = true;
        }
    }
}
