﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardDropChest : MonoBehaviour
{
    private bool isTrigger = false;
    [SerializeField] private TextMeshProUGUI itemNote;
    private DropItemManager dropItemManager;
    private DropItemStats itemStats;
    private DropItemLevel itemLevel;

    public bool isOpen = false;

    private void Start() {
        dropItemManager = GameObject.FindObjectOfType<DropItemManager>();
        UpdateVisualItem();
    }

    public void UpdateVisualItem() {
        string statText;

        if (itemStats != null && itemStats.itemName == "Sword Cooldown") {
            statText = "-" + itemLevel.bonusStat + "%";
        } else if (itemStats != null) {
            statText = "+" + itemLevel.bonusStat;
        } else {
            statText = "";
        }

        itemNote.text = (itemStats != null ? itemStats.itemName : "Unknown Item") + "\n" + statText;
    }

    public void GetDropItemStats( DropItemType type ) {
        itemStats = type.GetRandomDropItemStats();
        itemLevel = itemStats.GetRandomDropItemLevel();
    }

    private void OnTriggerEnter( Collider other ) {
        if (other.gameObject.CompareTag("Player") && !isTrigger) {
            Debug.Log("Đã nhặt dropitem");

            SoundManager.Instance.OpenChest(transform.position);
            isTrigger = true;
            isOpen = true;
            // Cập nhật item và phá hủy đối tượng
            dropItemManager.UpdateItem(itemStats, itemLevel.bonusStat);
            Destroy(gameObject, 0.5f);
        }
    }
}
