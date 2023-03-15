using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform playerPos, camPos;
    [Range (-20,20)] 
    [SerializeField]float offsetX, offsetY, offsetZ;
    [SerializeField]float smooth;
    [SerializeField]float tiltAngle;
    float tiltAroundY;
    // Start is called before the first frame update
    void Start()
    {
        camPos = GetComponent<Transform>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        camPos.position= new Vector3(playerPos.position.x + offsetX, playerPos.position.y + offsetY, playerPos.position.z + offsetZ);
        tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;

        Quaternion target = Quaternion.Euler(25.5f, tiltAroundY, 0.0f);

        camPos.rotation = Quaternion.Slerp(camPos.rotation, target,  Time.deltaTime * smooth);
    }
   
}
