using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header ("To make movement")]

    [SerializeField]float speedMov;
    Rigidbody playerRB;
    [SerializeField]Transform meshTrans;

    [Header ("Touch Joystick")]

    [SerializeField]Joystick touchControl;
    
    Animator playerAnims;
    ResetShoot underSc;

    [Header ("Actions")]
    [SerializeField] Button actionBtn;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        touchControl = GameObject.Find("MoveJoystick").GetComponent<FloatingJoystick>();
        playerAnims = GameObject.Find("NewPlayer").GetComponent<Animator>();
        underSc = GameObject.Find("NewPlayer").GetComponent<ResetShoot>();
        actionBtn = GameObject.Find("Action").GetComponent<Button>();
       
    }

    private void Update() 
    {
        if(!underSc.shooting)
        {
            playerAnims.SetFloat("speed", touchControl.Vertical);
            playerAnims.SetBool("isShooting", false);
        }
        else
        {
            playerAnims.SetFloat("speed", 0.0f);
            playerAnims.SetBool("isShooting", true);
        }
    }

    private void FixedUpdate() 
    {
        if(!underSc.shooting)
        {
            Movement();
            playerAnims.SetBool("isShooting", false);
        }
        
    }
    void Movement()
    {
        transform.Translate(Vector3.forward * touchControl.Vertical*speedMov);
    }
    private void OnTriggerStay(Collider other) {
        
        if(other.gameObject.CompareTag("Playable"))
        {
            actionBtn.interactable = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        
        if(other.gameObject.CompareTag("Playable"))
        {
            actionBtn.interactable = false;
            GameManager.Instance.RestartAction();
        }
    }
}
