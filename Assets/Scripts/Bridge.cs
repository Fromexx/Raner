using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Army"))
        {
            animator.SetTrigger("Up");
        }
    }
}
