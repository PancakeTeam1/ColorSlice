using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHit : MonoBehaviour
{
    public Animator Animator;
    
    public void Hit()
    {
        Animator.SetTrigger("StartHit");    
    }
}
