using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackDisplay : MonoBehaviour
{
    public int currentAttack;
    public Text attackText;

    // Start is called before the first frame update
    void Start()
    {
        currentAttack = 5;
        attackText.text = "Attack Power: " + currentAttack.ToString();
    }
    
    public void SetAttack(int attack){
        attackText.text = "Attack Power: " + attack.ToString();
    }

}
