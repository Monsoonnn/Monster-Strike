using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/ItemUpgrade")]
public class ItemUpgrade : ScriptableObject
{
    public string itemName;
    public Sprite image;
    public string type;

    public string note;
    public float minStat;
    public float maxStat;

    

    public float bonus {set; get; }

}
