using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyCreator : MonoBehaviour
{
    private float minX;
    private float maxX;
    private float minZ; 
    private float maxZ;
    [SerializeField] private Transform [] points;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float timeEnemy;
    private float timeToNext;
    [SerializeField]int cantEnemies;
    [SerializeField]int maxCantEnemies;

    // Start is called before the first frame update
    void Start()
    {
        maxX = points.Max ( points => points.position.x);
        minX = points.Min ( points => points.position.x);
        maxZ = points.Max ( points => points.position.z);
        minZ = points.Min ( points => points.position.z);


    }

    // Update is called once per frame
    void Update()
    {
        timeToNext += Time.deltaTime;
        if(timeToNext >= timeEnemy)
        {
            timeToNext = 0;
            if(cantEnemies<maxCantEnemies)
            {
                EnemyOn();
            }
            
        }
    
    }
    private void EnemyOn()
    {
        Vector3 randomPos = new Vector3 (Random.Range(minX,maxX),0.0f,Random.Range(minZ,maxZ));

        Instantiate (enemy, randomPos, Quaternion.identity);
        cantEnemies += 1;
    }
}