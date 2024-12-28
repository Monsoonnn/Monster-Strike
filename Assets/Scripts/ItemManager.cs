using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {


    [SerializeField] private List<GameObject> itemObj;

    public void UpdateItem( Item item, int starLevel) {

        if (item.itemName == "Double Monster") {
           
            GroundController ground = GameObject.FindAnyObjectByType<GroundController>();

            ground.DoubleMonsterCurrentTile();

            return;
        }

        // Tìm đối tượng trong danh sách itemObj dựa trên tên của item
        GameObject targetItem = FindGameObject(item);

        Component controller  = GetController(targetItem);

        if (controller == null ) {
            // Nếu controller trả về null 
            Debug.LogWarning("Không tìm thấy controller cho item!");
            return;
        } 


        if (controller is SwordController sword) {
          
           
        } else if (controller is ArrowController arrow) {
           /* Debug.Log("Đã cập nhật Arrow: ");*/
            if (item.itemName == "Crit Value") {
                arrow.levelCritGlasses = starLevel;
                /*Debug.Log("Đã cập nhật Arrow CV : ");*/
            } else if (item.itemName == "Lifesteal Necklace") {
                arrow.levelLifeSteal= starLevel;
               /* Debug.Log("Đã cập nhật Arrow LN: ");*/
            } else if (item.itemName == "Speedy Cape") {
                arrow.levelSpeedCape = starLevel;
/*                Debug.Log("Đã cập nhật Arrow SC: ");*/

            }


        } else if (controller is PlayerController player) {
            if (item.itemName == "Health") {
                player.health += (int)starLevel;
            } else if (item.itemName == "Impact Belt") {
                player.levelBelt = starLevel;
               /* Debug.Log("Đã cập nhật Impact Belt: ");*/

            }

           /* Debug.Log("Đã cập nhật health cho Player: " + player.health);*/
        }
    }

    public GameObject FindGameObject( Item item ) {
        
        foreach (GameObject obj in itemObj) {
 
            if (obj.gameObject.name == item.type) {
                return obj;
            }
        }
        return null;
    }

    public Component GetController( GameObject itemPrefab) {


        if (itemPrefab == null) {
            return GameObject.FindAnyObjectByType<PlayerController>();
        }

        if (itemPrefab.name.Contains("Sword")) {

            return itemPrefab.GetComponent<SwordController>();

        } else if (itemPrefab.name.Contains("Arrow")) {

            return itemPrefab.GetComponent<ArrowController>();

        } 

        return null;
    }


    public List<GameObject> GetItemList() {
        return itemObj;
    }


    public bool isMaxLevel( Component controller, Item item ) {

        if (item.itemName == "Double Monster") {

            return false;

        }


        if (controller is PlayerController player) {
            //Item nang cap cho player
            if (item.itemName == "Health") {
                return false;
            }
            if (item.itemName == "Impact Belt") {
                if (player.levelBelt < 4) {
                    return false;
                }
            }
        }
        if (controller is ArrowController arrow) {
            //Item nang cap cho arrow
            if (item.itemName == "Crit Value") {

                if (arrow.levelCritGlasses < 4) {
                    return false;
                }

            } else if (item.itemName == "Lifesteal Necklace") {

                if (arrow.levelLifeSteal < 4) {
                    return false;
                }

            } else if (item.itemName == "Speedy Cape") {

                if (arrow.levelSpeedCape < 4) {
                    return false;
                }
            }

        }
        if (controller is SwordController sword) {
            //Item nang cap cho sword

        }
        if (controller is WolfController wolf) {
            //Item nang cap cho wolf

        }

        return true;
    }
}
