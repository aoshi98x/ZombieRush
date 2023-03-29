using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image pocionImg;
    [SerializeField] ManageData counts;

    // Update is called once per frame
    void Update()
    {
        if (counts.damageToPlayer == 0 && counts.damageToEnemy == 1)
        {
            pocionImg.color = new Color (0,221,255,255);
        }
        else if(counts.damageToPlayer == 1 && counts.damageToEnemy == 2)
        {
            pocionImg.color = new Color (255,10,0,255);
        }
        else if (counts.damageToPlayer == 2 && counts.damageToEnemy == 3)
        {
            pocionImg.color = new Color (255,242,0,255);
        }
        else
        {
            pocionImg.color = new Color (49,49,49,255);
        }
    }
}
