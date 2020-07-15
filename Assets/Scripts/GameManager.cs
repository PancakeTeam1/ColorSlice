﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 currentCube;
    [HideInInspector]
    public Mode mode = Mode.Tape;

    public enum Mode
    {
        Canvas,
        Tape
    }

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mode == Mode.Tape)
                mode = Mode.Canvas;
            else
                mode = Mode.Tape;
        }
    }
}
