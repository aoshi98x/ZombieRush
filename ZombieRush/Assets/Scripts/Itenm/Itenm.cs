using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itenm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            ItenManager itemManager = GameObject.FindGameObjectWithTag("ManagerItenm")?.GetComponent<ItenManager>();

            if (itemManager != null)
            {

                itemManager.AumentarItenm();


                Destroy(gameObject);
            }
        }
    }
}


