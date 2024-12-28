using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreLayoutUI : MonoBehaviour {
    [SerializeField] private List<Item> Items; // Danh sách các vật phẩm
    [SerializeField] private GameObject itemUIPrefab; // Prefab giao diện vật phẩm
    

    private void Start() {
        Init();
    }

    void Init() {
        
        foreach (var item in Items) {
            CreateItemUI(item);
        }
    }

    private void CreateItemUI( Item item ) {
        // Tạo giao diện vật phẩm từ prefab
        GameObject itemUI = Instantiate(itemUIPrefab, transform);

        // Gắn thông tin vật phẩm vào UI
        var storeItemUI = itemUI.GetComponent<StoreItemUI>();
        if (storeItemUI != null) {
            storeItemUI.BaseItem = item; // `BaseItem` trong `StoreItemUI` cần đổi thành `Item`
        }
    }
}
