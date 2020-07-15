using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 currentCube;
    private Mode mode = Mode.Tape;
    enum Mode
    {
        Canvas,
        Tape
    }

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (mode == Mode.Tape)
        {

        }
    }

}
