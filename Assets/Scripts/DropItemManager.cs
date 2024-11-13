using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> itemObj;
    public void UpdateItem( DropItemStats item, float bonus ) {

        GameObject targetItem = FindGameObject(item);

        Component controller = GetController(targetItem);

        if (controller == null) {
            // Nếu controller trả về null 
            Debug.LogWarning("Không tìm thấy controller cho item!");
            return;
        }


        if (controller is SwordController sword) {
            if (item.itemName == "Sword Damage") {
                sword.damage += bonus;

            } else if (item.itemName == "Sword Distance") {
                sword.attackDistance += bonus;

            } else if (item.itemName == "Sword Cooldown") {
                sword.attackFrequency += bonus;

            } else if (item.itemName == "Sword Count") {
                sword.swordCount += (int)bonus;

            } else if (item.itemName == "Sword Speed") {
                sword.moveSpeed += bonus;

            }

        } else if (controller is ArrowController arrow) {
            /* Debug.Log("Đã cập nhật Arrow: ");*/
            if (item.itemName == "Arrow Damage") {
                arrow.Damage += (int)bonus;

            } else if (item.itemName == "Arrow Distance") {
                arrow.maxDistance += bonus;

            } else if (item.itemName == "Arrow Frequency") {
                arrow.arrowFrequency += bonus;

            } else if (item.itemName == "Arrow Speed") {
                arrow.speed += bonus;


            }


        } else if (controller is PlayerController player) {
            if (item.itemName == "Health") {
                player.health += (int)bonus;
            } else if (item.itemName == "Horizontal Speed") {
                player.horizontalSpeed += (bonus)/30.0f;
            }

        } else if (controller is WolfController wolf) {
            if (wolf.level == 0) {
                wolf.level = 1;
                wolf.isLevelUp = true;
            }
           

            wolf.maxCount += (int)bonus;
        }

    }

    public GameObject FindGameObject( DropItemStats item ) {

        foreach (GameObject obj in itemObj) {

            if (obj.gameObject.name == item.type) {
                return obj;
            }
        }
        return null;
    }

    public Component GetController( GameObject itemPrefab ) {


        if (itemPrefab == null) {
            return GameObject.FindAnyObjectByType<PlayerController>();
        }

        if (itemPrefab.name.Contains("Sword")) {

            return itemPrefab.GetComponent<SwordController>();

        } else if (itemPrefab.name.Contains("Arrow")) {

            return itemPrefab.GetComponent<ArrowController>();

        } else if (itemPrefab.name.Contains("Wolf")) {

            return itemPrefab.GetComponent<WolfController>();

        }

        return null;
    }

}
