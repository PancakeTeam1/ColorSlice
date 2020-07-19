using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHit : MonoBehaviour
{
    private Animator Animator;

    private void Awake()
    {
        Animator = this.GetComponent<Animator>();
    }

    public void Hit()
    {
        Animator.SetTrigger("StartHit");    
    }
}
