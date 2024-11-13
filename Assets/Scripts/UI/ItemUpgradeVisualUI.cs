using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class ItemUpgradeVisualUI : MonoBehaviour {
    [SerializeField] private Image item_image;
    [SerializeField] private TextMeshProUGUI item_note;

    ItemManager itemManager;
    public int starLevel;
    public Item itemTemp { get; private set; }


    public void VisualUpdate( Item item ) {

        item_image.sprite = item.image;
        itemTemp = item;
        starLevel = getLevel(item);

    }

    public int getLevel( Item item ) {

        itemManager =  GameObject.FindAnyObjectByType<ItemManager>();

        GameObject targetItem = itemManager.FindGameObject(item);

        Component controller = itemManager.GetController(targetItem);

        if (controller is ArrowController arrow) {
            
            if (item.itemName == "Crit Value") {
                starLevel = arrow.levelCritGlasses + 1;
              
                if (item is BaseItem_critValue critItem) {
                    item_note.text =
                        "Crit Rate:" + critItem.critRate[starLevel] + "%\n" +
                        "Crit Damage: " + critItem.critDamage[starLevel] +"%\n";
                }
                return starLevel;

            } else if (item.itemName == "Lifesteal Necklace") {
                starLevel = arrow.levelLifeSteal + 1;
               
                if (item is BaseItem_Support supItem) {
                    item_note.text =
                        "Life Steal:" + supItem.itemStatByLevel[starLevel] + "%\n";
                }
                return starLevel;

            } else if (item.itemName == "Speedy Cape") {
                starLevel = arrow.levelSpeedCape + 1;
               
                if (item is BaseItem_Support supItem) {
                    item_note.text =
                        "Transfer Speed to Dmg:" + supItem.itemStatByLevel[starLevel] + "%\n";
                }
                return starLevel;
            }

        } else if (controller is PlayerController player) {

            if (item is ItemUpgrade healh) {

                int bonus = (int)Random.Range(healh.minStat, healh.maxStat);

                item_note.text = "Health bonus: " + bonus;

                return bonus;
            } else if (item.itemName == "Impact Belt") {

                starLevel = player.levelBelt + 1;

                if (item is BaseItem_Support supItem) {
                    item_note.text =
                        "Reduce Damage:" + supItem.itemStatByLevel[starLevel] + "% \n";
                }
                return starLevel;
            }

        }
        item_note.text = "X2 Monster";
        return 0;

    }
}
