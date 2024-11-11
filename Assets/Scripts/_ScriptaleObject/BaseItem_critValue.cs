using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/CritGlasses")]
public class BaseItem_critValue : ScriptableObject
{
    public string itemName;

    public Sprite image;

    public int level;


    public List<int> critRate;
    public List<int> critDamage;


    public int totalDamage( int baseDamage, int level ) {
        int rate = critRate[level];
        int critDmg = critDamage[level];

        // Tính toán tỷ lệ chí mạng
        float randomValue = Random.Range(0f, 100f);
        if (randomValue < rate) { // Xảy ra chí mạng
            return baseDamage * critDmg / 100;
        } else { // Không chí mạng
            return baseDamage;
        }
    }

}
