using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/BaseItem_Sup")]
public class BaseItem_Support : Item 
{


    public List<int> itemStatByLevel;


    // Impact Belt
    public int reduceDamage( float monsterHealh, int level ) {

        return (int)(monsterHealh - itemStatByLevel[level]);
        
    }

    // Crit

    public float BonusDamage( float speed, int level ) {
        if (level > 0) {
            return speed * (itemStatByLevel[level] / 100.0f);
        }

        return 0;

    }

    //LifeSteal

    public float BonusHealth( int damage, int level ) {

        if (level > 0) {
            return damage * (itemStatByLevel[level] / 100.0f);
        }


        return 0;
    }

}
