using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUpgradeVisualUI : MonoBehaviour {
    [SerializeField] private Image item_image;
    [SerializeField] private TextMeshProUGUI item_note;

    public ItemUpgrade itemTemp { get; private set; }
    
    public void VisualUpdate( ItemUpgrade item, float bonus) { 

        item_image.sprite = item.image;
        item_note.text = item.note + " " + (int)bonus;
        itemTemp = item;

    }


}
