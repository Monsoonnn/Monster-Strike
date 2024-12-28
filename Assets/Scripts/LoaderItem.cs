using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderItem : MonoBehaviour
{
    [SerializeField] private List<Item> Items;


    private void Update() {
        LoadItem();
    }

    void LoadItem() {
        foreach (var item in Items) {

            int level = PlayerPrefs.GetInt(item.itemName);
            if (level != item.level) { 
                item.level = level;
            }

        }
    }
}

