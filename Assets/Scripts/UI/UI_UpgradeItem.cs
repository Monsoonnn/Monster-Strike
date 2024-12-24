using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UpgradeItem : MonoBehaviour {

    [SerializeField] private List<Item> upgradeItemList;

    [SerializeField] private GameObject itemChoice;

    private List<Item> selectedUpgrades = new List<Item>();

    [SerializeField] private GameObject tableChoice;

    private UIManager manager;

    ItemManager itemManager;
    private void Start() {
        Hide();
        selectedUpgrades.Clear(); 
        itemManager = GameObject.FindAnyObjectByType<ItemManager>();

        manager = GameObject.FindObjectOfType<UIManager>();
    }


    public void ShowItem() {

        ClearChoice();

        GenerateRandomUpgrades();

        ItemUpgradeVisualUI visual = itemChoice.gameObject.GetComponent<ItemUpgradeVisualUI>();

        int count = 0;

        foreach (Item upgrade in selectedUpgrades) {

            if(count >= 3 ) { break; }

            ItemUpgradeVisualUI itemChoice = Instantiate(visual,tableChoice.transform.position, tableChoice.transform.rotation, tableChoice.transform); 
            
            itemChoice.VisualUpdate(upgrade);

            count++;

        }


    }


    public void ClearChoice() {

        selectedUpgrades.Clear();

        foreach (Transform child in tableChoice.transform) {
            Destroy(child.gameObject); 
        }
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
   

    private void GenerateRandomUpgrades() {

        // Tạo bản sao của upgradeItemList để có thể thao tác mà không làm thay đổi danh sách gốc
        List<Item> tempList = new List<Item>(upgradeItemList);

        while (selectedUpgrades.Count < 3 && tempList.Count > 0)
        {
            int randomIndex = Random.Range(0, tempList.Count);


            GameObject targetItem = itemManager.FindGameObject(tempList[randomIndex]);

            Component controller = itemManager.GetController(targetItem);

            if (itemManager.isMaxLevel(controller, tempList[randomIndex])) { // Nếu đã đạt max level thì skip 
                tempList.RemoveAt(randomIndex);
                continue;
            }
            
            selectedUpgrades.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex);

        }

    }

}
