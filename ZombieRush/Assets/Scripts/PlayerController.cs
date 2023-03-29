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
    public float life = 100;
    [SerializeField] ManageData counts;
    [SerializeField]Slider lpSlider;
    [SerializeField] float timeToDamage;
    [SerializeField] bool zombieAttack;
    [Header ("AudioClips")]
    [SerializeField]AudioClip hurt;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        touchControl = GameObject.Find("MoveJoystick").GetComponent<FloatingJoystick>();
        playerAnims = GameObject.Find("NewPlayer").GetComponent<Animator>();
        underSc = GameObject.Find("NewPlayer").GetComponent<ResetShoot>();
        actionBtn = GameObject.Find("Action").GetComponent<Button>();
        lpSlider = GameObject.Find("LP").GetComponent<Slider>();
    }

    private void Update() 
    {
        lpSlider.value = life;
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
        if(zombieAttack)
        {
            timeToDamage += Time.deltaTime;
            
            if(timeToDamage >= 0.7 && timeToDamage <= 0.9)
            {
                life -= 1;
                
            }
            else if(timeToDamage >=2.0f)
            {
                timeToDamage = 0;
            } 
        }
        if(underSc.shooting)
        {
            life -= counts.damageToPlayer*0.036f;
        }
        
    }
    void Movement()
    {
        transform.Translate(Vector3.forward * touchControl.Vertical*speedMov);
    }
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.CompareTag("zombie"))
        {
            zombieAttack = true;
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("zombie"))
        {
           AudioManager.Instance.PlaySfx(hurt);
        }
    }
    
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("zombie"))
        {
            zombieAttack = false;
        }
    }
    private void OnTriggerStay(Collider other) {
        
        if(other.gameObject.CompareTag("Playable"))
        {
            actionBtn.interactable = true;
        }
        if(other.gameObject.CompareTag("NextLvl"))
        {
            GameManager.Instance.CheckLevel();
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
