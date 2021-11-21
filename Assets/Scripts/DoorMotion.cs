using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorSqueak;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorSqueak = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("DoorIsOpenning", true);
        doorSqueak.PlayDelayed(0.5f);
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorIsOpenning", false);
        doorSqueak.PlayDelayed(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
