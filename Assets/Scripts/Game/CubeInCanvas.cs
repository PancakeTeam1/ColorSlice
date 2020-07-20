using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInCanvas : MonoBehaviour
{
    //Это не координата в пространстве, а координата в холсте
    [HideInInspector]public Vector2Int PosInCanvas;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void OnMouseDown()
    {
        if (gameManager.ModeCondition == GameManager.Mode.Canvas)
            gameManager.PressCube(this);

    }
}
