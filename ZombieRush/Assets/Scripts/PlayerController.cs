using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    [SerializeField]float inputAngle = 60.0f; 
    [SerializeField]float speedMov;
    [SerializeField]Joystick touchControl;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        RotationPl();
    }
    private void FixedUpdate() 
    {
        Movement();
        
    }
    void Movement()
    {
        transform.position += transform.forward * Time.deltaTime *(speedMov * touchControl.Vertical);
        transform.position += transform.right * Time.deltaTime *(speedMov * touchControl.Horizontal);
         //playerRB.MovePosition(transform.forward + input * Time.deltaTime * speedMov);
    }
    void RotationPl()
    {
        //Player Rotation
        transform.Rotate(0.0f, touchControl.Horizontal * inputAngle, 0.0f);
    }
}
