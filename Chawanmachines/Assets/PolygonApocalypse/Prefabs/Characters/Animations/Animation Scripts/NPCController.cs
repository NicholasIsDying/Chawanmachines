using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    [SerializeField] public GameObject NPC;
    [SerializeField] public GameObject Destination;
    
    public float speed;

    Animator animator;
    bool StartWalking;
    bool StopWalking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        while (StartWalking == true)
        {
            NPC.transform.position = Vector3.MoveTowards(NPC.transform.position, Destination.transform.position, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start Trigger"))
        {
            animator.SetBool("StopWalking", false);
            animator.SetBool("StartWalking", true);
            StartWalking = true;
            StopWalking = false;
        }
        
        if (other.CompareTag("End trigger"))
        {
            animator.SetBool("StartWalking", false);
            animator.SetBool("StopWalking", true);
            StartWalking = false;
            StopWalking = true;
        }
    }
}
