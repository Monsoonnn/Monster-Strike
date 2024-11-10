using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Item")]
public class BaseItem : ScriptableObject
{
    public string itemName;

    public float speed;

    public float frequency;

    public float damage;

    public float maxDistance;

    public float count;

    public float attackDistance;
}
