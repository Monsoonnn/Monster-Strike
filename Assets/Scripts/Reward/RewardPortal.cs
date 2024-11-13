using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class RewardPortal : MonoBehaviour
{
    private bool isTrigger = false;
    [SerializeField] private TextMeshProUGUI itemNote;
    private DropItemManager dropItemManager;
    private DropItemStats itemStats;
    private DropItemLevel itemLevel;

    private void Start() {
        dropItemManager = GameObject.FindObjectOfType<DropItemManager>();
        UpdateVisualItem();
    }

    public void UpdateVisualItem() {

        string statText;
        // Cập nhật horizontal
        if (itemStats.itemName == "Sword Cooldown") {
            statText = "-" + itemLevel.bonusStat + "%";
        } else {
            statText = "+" + itemLevel.bonusStat;
        }

        itemNote.text = itemStats.itemName + "\n" + statText;
    }




    public void GetDropItemStats( DropItemType type ) {


        itemStats = type.GetRandomDropItemStats();

       /* Debug.Log(itemStats.ToString());*/

        itemLevel = itemStats.GetRandomDropItemLevel();

    }


    private void OnTriggerEnter( Collider other ) {
        if (other.gameObject.CompareTag("Player") && !isTrigger) {
            Debug.Log("Đã nhặt dropitem");
            isTrigger = true;
            dropItemManager.UpdateItem(itemStats, itemLevel.bonusStat);

        }
    }

    private void OnTriggerExit( Collider other ) {
        if (other.gameObject.CompareTag("Player")) {

            Destroy(gameObject, 2);

        }
    }

}
