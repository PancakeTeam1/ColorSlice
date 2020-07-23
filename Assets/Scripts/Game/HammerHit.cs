using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHit : MonoBehaviour
{
    private Animator Animator;
    private GameManager gameManager;
    private bool cooldown;
    private float delay = 0.3f;

    private void Awake()
    {
        Animator = this.GetComponent<Animator>();
        gameManager = GameManager.Instance;
    }

    public void Hit()
    {
        if (GameManager.Instance.ModeCondition == GameManager.Mode.Band)
            Animator.SetTrigger("StartHit");    
        gameManager.IsHitbutton = true;
    }

    private IEnumerator StartTimer()
    {
        cooldown = true;
        yield return new WaitForSeconds(delay);
        cooldown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!cooldown)
            StartCoroutine(StartTimer());
    }
}
