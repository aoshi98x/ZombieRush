using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingForce : MonoBehaviour
{
    Rigidbody rbProyectile;
    [Range (0,20)] public float speed;
    [SerializeField]GameObject splashEffect;
    // Start is called before the first frame update
    private void OnEnable() 
    {
      rbProyectile = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rbProyectile.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject)
        {
            SplashEffect();
            Destroy(this.gameObject);
        }
    }
    void SplashEffect()
    {
        Instantiate(splashEffect, transform.position, transform.rotation);
    }
}
