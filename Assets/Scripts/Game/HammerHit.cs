using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHit : MonoBehaviour
{
    private Animator Animator;
    private GameManager gameManager;

    private void Awake()
    {
        Animator = this.GetComponent<Animator>();
        gameManager = GameManager.Instance;
    }

    public void Hit()
    {
        Animator.SetTrigger("StartHit");
        gameManager.IsHitbutton = true;
    }
}
