using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/DI_stats")]
public class DropItemStats : ScriptableObject
{
    public string itemName;
    public Sprite image;
    public float dropRate;
    public string type;

    public List<DropItemLevel> listItemLevel;

    public DropItemLevel GetRandomDropItemLevel() {

        float totalDropRate = 100f;


        float randomValue = Random.Range(0, totalDropRate);

        // Duyệt qua các mục trong danh sách và chọn ra một mục theo xác suất
        float cumulative = 0f;
        foreach (var item in listItemLevel) {
            cumulative += item.dropRate;
            if (randomValue < cumulative) {
                return item;
            }
        }


        return null;
    }
}
