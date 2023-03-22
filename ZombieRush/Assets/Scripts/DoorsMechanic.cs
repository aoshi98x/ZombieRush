using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsMechanic : MonoBehaviour
{
    [SerializeField]Transform doorTrans;
    [SerializeField]GameManager checkBool;
    bool isPossible;
    // Start is called before the first frame update
    void Start()
    {
        doorTrans = GetComponent<Transform>();
        checkBool = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkBool.doAction && isPossible)
        {
            doorTrans.localRotation = Quaternion.Euler(doorTrans.localRotation.x, 90, doorTrans.rotation.z);
            doorTrans.localPosition = new Vector3 (-0.22f, doorTrans.localPosition.y, -0.4f);
        }
        else if (!isPossible)
        {
            doorTrans.localRotation = Quaternion.Euler(doorTrans.localRotation.x, 0, doorTrans.rotation.z);
            doorTrans.localPosition = new Vector3 (-0.505f, doorTrans.localPosition.y, 0.397f);
        }
    }
    private void OnTriggerStay(Collider other) {
        
        if(other.gameObject.CompareTag("Player"))
        {
            isPossible = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        
        if(other.gameObject.CompareTag("Player"))
        {
            isPossible = false;
        }
    }
}
