using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/DI_Type")]
public class DropItemType : ScriptableObject
{
    public string itemName;
    public float dropRate;


    public List<DropItemStats> dropItemRate;

    public DropItemStats GetRandomDropItemStats() {
  
        float totalDropRate = dropItemRate.Sum(item => item.dropRate);

       
        float randomValue = Random.Range(0, totalDropRate);

        // Duyệt qua các mục trong danh sách và chọn ra một mục theo xác suất
        float cumulative = 0f;
        foreach (var item in dropItemRate) {
            cumulative += item.dropRate;
            if (randomValue < cumulative) {
                return item;
            }
        }

        
        return null;
    }

}
