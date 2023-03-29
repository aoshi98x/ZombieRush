using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionChange : MonoBehaviour
{
    [SerializeField] Material liquid;
    [SerializeField] ManageData counts;
    public int randomColor;
    [SerializeField]int result;
    public AudioClip take;
    // Start is called before the first frame update
    void Start()
    {
        randomColor = Random.Range(0,2);
        if(randomColor== 0)
        {
            liquid.color = new Color(0.21f,0.71f,0.8f,1.0f);//Blue
            result = counts.pocionBlue + randomColor;
        }
        else if(randomColor == 1)
        {
            liquid.color = new Color(1.0f,0.84f,0.13f,1.0f);//Yellow
            result = counts.pocionYellow + randomColor;
        }
        else if(randomColor == 2)
        {
            
            liquid.color = new Color(0.8f,0.29f,0.24f,1.0f);//Red
            result = counts.pocionRed + randomColor;
        }
    }
   
    private void OnTriggerEnter(Collider other) 
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            
            switch (result)
            {
                case 1:
                    counts.damageToPlayer = 0;
                    counts.damageToEnemy = 1;
                break;

                case 3:
                    counts.damageToPlayer = 1;
                    counts.damageToEnemy = 2;
                break;

                case 4:
                    counts.damageToPlayer = 2;
                    counts.damageToEnemy = 3;
                break;

                default:
                    counts.damageToPlayer = 0;
                    counts.damageToEnemy = 0;
                break;
            }
            
            AudioManager.Instance.PlaySfx(take);
            StartCoroutine(DestroyThis());
        }
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
