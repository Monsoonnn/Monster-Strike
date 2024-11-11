using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Item")]
public class BaseItem : ScriptableObject
{
    public string itemName;

    public Sprite image;

    public float speed;

    public int level;

    public float maxDistance;

    public float attackDistance;

    public List<float> damageByLevel; // Tính từ lv 0

    public List<float> frequencyByLevel;

    public List<float> countByLevel;

}
