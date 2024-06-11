using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    [SerializeField] public GameObject NPC;
    [SerializeField] public GameObject Destination;
    public GameObject Camera;
    public float speed;

    Animator animator;
    public bool StartWalking;
    bool StopWalking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        StartTrigger();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartWalking == true)
        {
            var direction = (Destination.transform.position - transform.position).normalized;
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 90 * Time.deltaTime);
            NPC.transform.position = Vector3.MoveTowards(NPC.transform.position, Destination.transform.position, speed);
        }
        else
        {
            var direction = (new Vector3(Camera.transform.position.x, transform.position.y, Camera.transform.position.z) - transform.position).normalized;

            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 90 * Time.deltaTime);
        }

    }

    void StartTrigger()
    {
        animator.SetBool("StopWalking", false);
        animator.SetBool("StartWalking", true);
        StartWalking = true;
        StopWalking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start Trigger"))
        {
            StartTrigger();
        }
        
        if (other.CompareTag("End Trigger"))
        {
            print("e");
            animator.SetBool("StartWalking", false);
            animator.SetBool("StopWalking", true);
            StartWalking = false;
            StopWalking = true;
        }
    }
}
