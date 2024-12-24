using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnUpgradeItem : BaseBtn
{
    private Item item;
    private ItemUpgradeVisualUI itemUpgradeVisualUI;
    private ItemManager itemManager;
    private UI_UpgradeItem upgradeTableItem;

    private UIManager uiManager;




    protected override void OnClick() {
        uiManager = GameObject.FindAnyObjectByType<UIManager>();

        itemManager = GameObject.FindAnyObjectByType<ItemManager>();
        upgradeTableItem = GameObject.FindObjectOfType<UI_UpgradeItem>();

        itemUpgradeVisualUI = transform.parent.gameObject.GetComponent<ItemUpgradeVisualUI>();

        item = itemUpgradeVisualUI.itemTemp;

        itemManager.UpdateItem(item, itemUpgradeVisualUI.starLevel);
        
        upgradeTableItem.Hide();
        upgradeTableItem.ClearChoice();

        if (uiManager.isGamePause) { 
            uiManager.GameContinue();
            uiManager.isPickingItem = false;
        }




    }
}
