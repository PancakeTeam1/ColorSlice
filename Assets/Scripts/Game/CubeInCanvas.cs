using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInCanvas : MonoBehaviour
{
    //Это не координата в пространстве, а координата в холсте
    [HideInInspector]public Vector2Int PosInCanvas;
    [HideInInspector]
    public Material mat;
    private GameManager gameManager;
    [HideInInspector]
    public bool isFree = false;


    private void Awake()
    {
        mat = GetComponent<Renderer>().materials[0];
        gameManager = GameManager.Instance;
    }

    public void PutCubeBand()
    {
        mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 1f);
        isFree = true;
    }

    private void OnMouseDown()
    {
        if (gameManager.ModeCondition == GameManager.Mode.Canvas)
            gameManager.PressCube(this);

    }
}
