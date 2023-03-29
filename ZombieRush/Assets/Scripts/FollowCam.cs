using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("Transform of player and cam")]
    [SerializeField] Transform playerPos;
    [SerializeField] Transform camPos;
    
    [Header("Offset and variables to modify Transform")]
     
    [Range (-20,20)] [SerializeField]float offsetX;
    [Range (-20,20)] [SerializeField]float offsetY;
    [Range (-20,20)] [SerializeField]float offsetZ;
    
    [Header("Touch Joystick")]
    
    [SerializeField]Joystick touchCamControl;
    //[SerializeField]Joystick CamControl;
    
    [Header("Values to do the rotations")]
    [SerializeField]float smooth;
    [SerializeField]float tiltAngle;
    [SerializeField]float tiltAroundY;
    [SerializeField]float horizontal;
  
    void Start()
    {
        camPos = GetComponent<Transform>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        touchCamControl = GameObject.Find("MoveJoystick").GetComponent<FloatingJoystick>();
        //CamControl = GameObject.Find("MoveCam").GetComponent<FloatingJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = touchCamControl.Horizontal;
        //Cam adopt the player position with:
        camPos.position = new Vector3(playerPos.position.x + offsetX, playerPos.position.y + offsetY, playerPos.position.z + offsetZ);
        Rotation();
            
       
    }
    void Rotation()
    {
        //This the way how the cam rotate with player:
        tiltAroundY = touchCamControl.Horizontal * tiltAngle;

         //Rotation of cam and player respectively:
        if(horizontal >= 0.5f || horizontal <=-0.5f)
        {
            camPos.Rotate(0.0f,tiltAroundY*smooth,0.0f);
            playerPos.rotation = camPos.rotation; 
            Debug.Log("Se puede bitch!");
        }
        
    }

   
}