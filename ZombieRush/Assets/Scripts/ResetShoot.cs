using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetShoot : MonoBehaviour
{
    public bool shooting;
    [SerializeField]GameObject proyectile;
    [SerializeField] Transform pointShooting;
    private void Start() 
    {
        pointShooting = GameObject.Find("ShootPoint").GetComponent<Transform>();    
    }
    public void Shooting()
    {
        shooting = true;
        Instantiate(proyectile, pointShooting.position, pointShooting.rotation);
    }
    public void NoShooting()
    {
        shooting = false;
        
    }
}
