using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ID") || other.CompareTag("Entry"))
        {
            Destroy(other.gameObject, 2f);
        }
    }

   
}
