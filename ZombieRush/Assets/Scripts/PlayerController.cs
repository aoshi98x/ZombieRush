using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    float rotationY;
    float movZ, movX;
    Vector3 input;
    [SerializeField]float smoothMov = 5.0f;
    [SerializeField]float inputAngle = 60.0f; 
    [SerializeField]float speedMov;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //inputs to values
        rotationY = Input.GetAxis("Horizontal")* inputAngle;
        movZ = Input.GetAxis("Vertical");
        movX = Input.GetAxis("Horizontal");
        input = new Vector3(movX, 0.0f, movZ);
        //Player Rotation
        Quaternion target = Quaternion.Euler(0.0f, rotationY, 0.0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smoothMov);
        
    }
    private void FixedUpdate() 
    {
        Movement();
    }
    void Movement()
    {
         playerRB.MovePosition(transform.position + input * Time.deltaTime * speedMov);
    }
}
