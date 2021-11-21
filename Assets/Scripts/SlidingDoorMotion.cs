using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();// THIS must have a component Animator
        doorSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("open", true);
        doorSound.PlayDelayed(0.8f);
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("open", false);
        doorSound.PlayDelayed(0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
