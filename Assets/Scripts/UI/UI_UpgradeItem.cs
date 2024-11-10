using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UpgradeItem : MonoBehaviour {

    [SerializeField] private List<ItemUpgrade> upgradeItemList;

    [SerializeField] private GameObject itemChoice;

    private List<ItemUpgrade> selectedUpgrades = new List<ItemUpgrade>();

    [SerializeField] private GameObject tableChoice;
    private void Start() {
        Hide();

    }


    public void ShowItem() {
        GenerateRandomUpgrades();

        ItemUpgradeVisualUI visual = itemChoice.gameObject.GetComponent<ItemUpgradeVisualUI>();

        foreach (ItemUpgrade upgrade in selectedUpgrades) {

            ItemUpgradeVisualUI itemChoice = Instantiate(visual,tableChoice.transform.position, tableChoice.transform.rotation, tableChoice.transform);

            upgrade.bonus = Random.Range(upgrade.minStat, upgrade.maxStat);
            
            
            itemChoice.VisualUpdate(upgrade, upgrade.bonus);

        }


    }


    public void ClearChoice() {

        selectedUpgrades.Clear();

        foreach (Transform child in tableChoice.transform) {
            Destroy(child.gameObject); 
        }
    }

    public void GameContinue() {
        Time.timeScale = 1.0f;  
    }

    public void GamePause() {
        Time.timeScale = 0f;
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
   

    private void GenerateRandomUpgrades() {

        // Tạo bản sao của upgradeItemList để có thể thao tác mà không làm thay đổi danh sách gốc
        List<ItemUpgrade> tempList = new List<ItemUpgrade>(upgradeItemList);

        for (int i = 0; i < 3; i++) {
            int randomIndex = Random.Range(0, tempList.Count);
            selectedUpgrades.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex);
        }

        // In ra danh sách các upgradeItem đã chọn
        foreach (var item in selectedUpgrades) {
            Debug.Log("Selected Upgrade Item: " + item.name);
        }
    }

}
