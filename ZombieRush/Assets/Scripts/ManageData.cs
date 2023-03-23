using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "ManageDataFile", order = 0)]

public class ManageData : ScriptableObject {
    public int pocionblue, pocionRed, pocionYellow;
    public int damageToPlayer;
    public int damageToEnemy;
    
}
