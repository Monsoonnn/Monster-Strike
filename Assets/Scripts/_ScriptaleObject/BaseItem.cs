using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Item")]
public class BaseItem : Item
{

    public float speed;

    public float maxDistance;

    public float attackDistance;

    public List<float> damageByLevel; // Tính từ lv 0

    public List<float> frequencyByLevel;

    public List<float> countByLevel;

}
