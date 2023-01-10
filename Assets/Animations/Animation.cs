using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator mAnimator;
    private bool enRotation = false;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!enRotation)
        {
            enRotation = true;
            StartCoroutine(Wait(3.0f));
        }
    }
    IEnumerator Wait(float seconds)
    {
        mAnimator.SetTrigger("TrRotation");
        yield return new WaitForSeconds(seconds);
        enRotation = false;
        
    }
}


