using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/ItemUpgrade")]
public class ItemUpgrade : Item
{

    public string note;

    public float minStat;
    public float maxStat;

    public float bonus {set; get; }

}
