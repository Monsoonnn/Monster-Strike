using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDropItem : MonoBehaviour
{

    [SerializeField] private List<DropItemType> dropItems;


    public DropItemType GetRandomDropItem() {

        float totalDropRate = 100.0f;


        float randomValue = Random.Range(0, totalDropRate);

        // Duyệt qua các mục trong danh sách và chọn ra một mục theo xác suất
        float cumulative = 0f;
        foreach (var item in dropItems) {
            cumulative += item.dropRate;
            if (randomValue < cumulative) {
                return item;
            }
        }


        return null;
    }
}
