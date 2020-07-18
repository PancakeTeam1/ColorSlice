using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHit : MonoBehaviour
{
    private Animator Animator;

    private void Start()
    {
        Animator = this.GetComponent<Animator>();
    }

    public void Hit()
    {
        Animator.SetTrigger("StartHit");    
    }
}
