using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {


    [SerializeField] private List<GameObject> itemObj;

    public void UpdateItem( ItemUpgrade item, float bonus) {

        // Tìm đối tượng trong danh sách itemObj dựa trên tên của item
        GameObject targetItem = FindGameObject(item);

        Component controller  = GetController(targetItem);

        if (controller == null) {
            Debug.LogWarning("Không tìm thấy controller cho item!");
            return;
        }

        
        if (controller is SwordController sword) {
            sword.damage += (int)bonus;
            Debug.Log("Đã cập nhật damage cho Sword: " + sword.damage);
        } else if (controller is ArrowController arrow) {
            arrow.speed += bonus; 
            Debug.Log("Đã cập nhật speed cho Arrow: " + arrow.speed);
        } else if (controller is PlayerController player) {
            player.health += (int)bonus; 
            Debug.Log("Đã cập nhật health cho Player: " + player.health);
        }
    }

    public GameObject FindGameObject( ItemUpgrade item ) {
        foreach (GameObject obj in itemObj) {
            if (obj.gameObject.name == item.itemName ){
                return obj;
            }
        }
        return null;
    }

    public Component GetController( GameObject item ) {

        if (item == null) {
            return GameObject.FindAnyObjectByType<PlayerController>();
        }

        if (item.name.Contains("Sword")) {
            return item.GetComponent<SwordController>();
        } else if (item.name.Contains("Arrow")) {
            return item.GetComponent<ArrowController>();
        } 
        
        return null;
    }


    public List<GameObject> GetItemList() {
        return itemObj;
    }
}
