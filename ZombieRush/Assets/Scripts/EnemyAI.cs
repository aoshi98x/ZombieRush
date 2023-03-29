using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    [SerializeField]Transform objective;
    NavMeshAgent agent;
    [SerializeField]Animator enemyAnim;
    public bool kill = false;
    public bool isAttack = false;
    Collider collider;
    [SerializeField] ManageData counts;
    public int life;
    [Header ("AudioClips")]
    [SerializeField]AudioClip hurt, talk, dead;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponentInChildren<Animator>();
        objective = GameObject.Find("Player").GetComponent<Transform>();
        collider= GetComponent<Collider>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(objective.position);
        
        if (agent.speed >= 0.3f)
        {
            enemyAnim.SetBool("isWalk", true);
        }
        if(life <=0)
        {
            kill = true;
        }
        if(kill)
        {
            counts.enemyDestroy += 1;
            AudioManager.Instance.PlaySfx(dead);
            agent.speed = 0.0f;
            collider.enabled=false;
            enemyAnim.SetBool("isDead", true);
            enemyAnim.SetBool("isWalk", false);
            enemyAnim.SetBool("isATK", false);
            StartCoroutine(DestroyThis());
            kill = false;
           
        }
        if(enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }
        
    }
    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            Debug.Log("Es el topo!");
            AudioManager.Instance.PlaySfx(talk);
            enemyAnim.SetBool("isATK", true);
            enemyAnim.SetBool("isWalk", false);
            agent.speed = 0.0f;
            isAttack = true;
        }
        
    }
    void OnTriggerExit (Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            agent.speed = 0.3f;
            enemyAnim.SetBool("isATK", false);
            enemyAnim.SetBool("isWalk", true);
            
        }
    }
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("bullet"))
        {
            life -= counts.damageToEnemy;
            AudioManager.Instance.PlaySfx(hurt);
            enemyAnim.SetBool("damageOn", true);
            enemyAnim.SetBool("isWalk", false);
            enemyAnim.SetBool("isATK", false);
            StartCoroutine(Resume());
        }    
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(2.6f);
        Destroy(this.gameObject);
    }
    IEnumerator Resume()
    {
        yield return new WaitForSeconds(1.0f);
        enemyAnim.SetBool("damageOn", false);
        enemyAnim.SetBool("isWalk", true);
    }
}