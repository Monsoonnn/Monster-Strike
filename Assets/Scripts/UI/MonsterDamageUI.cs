using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterDamageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI healthText;



    public void DamageUI( float damage ) {
        
        damageText.text = "-" + damage.ToString();
        TextMeshProUGUI dmgText = Instantiate( damageText, transform.position, Quaternion.identity, transform);
        
    }

    public void healhUpdate(int health) { 
        healthText.text = health.ToString();
    }


}
