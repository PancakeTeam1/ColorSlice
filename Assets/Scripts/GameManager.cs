using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool IsButton = false;
    public bool IsPaused = false;
    public Vector3 currentCube;
    private Mode mode = Mode.Tape;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(IsButton)
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

    enum Mode
    {
        Canvas,
        Tape
    }
}
