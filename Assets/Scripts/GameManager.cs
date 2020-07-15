using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject PauseMenu;
    public bool IsButton = false;
    public bool IsPaused = false;

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
=======
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

>>>>>>> 44cdf3f619dad335ac8542e9304413e975c02977
}
