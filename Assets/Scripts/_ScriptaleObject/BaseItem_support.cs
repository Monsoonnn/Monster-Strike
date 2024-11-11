using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/BaseItem_Sup")]
public class BaseItem_Support : ScriptableObject 
{
    public string itemName;

    public Sprite image;

    public int level;

    public List<int> itemStatByLevel;


    // Impact Belt
    public int reduceDamage( int monsterHealh, int level ) {
        
        return monsterHealh - itemStatByLevel[level];
        
    }

    public float BonusDamage( float speed, int level ) {
        if (level > 0) {
            return speed * (itemStatByLevel[level] / 100.0f);
        }

        return 0;

    }

}
