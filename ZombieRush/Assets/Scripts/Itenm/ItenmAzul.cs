using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenmAzul : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            ItenManager itemManager = GameObject.FindGameObjectWithTag("ManagerItenm")?.GetComponent<ItenManager>();

            if (itemManager != null)
            {

                itemManager.AumentarItenmAzul();


                Destroy(gameObject);
            }
        }
    }
}
