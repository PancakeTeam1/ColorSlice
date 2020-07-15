﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    [HideInInspector]
    public bool IsButton = false;
    [HideInInspector]
    public bool IsPaused = false;
    public Vector3 currentCube;
    [HideInInspector]
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mode == Mode.Tape)
                mode = Mode.Canvas;
            else
                mode = Mode.Tape;
        }
        if (IsButton)
        {
            IsPaused = !IsPaused;
            PauseMenu.SetActive(IsPaused);
            Time.timeScale = IsPaused ? 0 : 1;
            IsButton = false;
        }
    }
    
    public void OnClick()
    {
        IsButton = true;
    }
}
