using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnUpgradeItem : BaseBtn
{
    private Item item;
    private ItemUpgradeVisualUI itemUpgradeVisualUI;
    private ItemManager itemManager;
    private UI_UpgradeItem upgradeTableItem;


    protected override void OnClick() {

        itemManager = GameObject.FindAnyObjectByType<ItemManager>();
        upgradeTableItem = GameObject.FindObjectOfType<UI_UpgradeItem>();

        itemUpgradeVisualUI = transform.parent.gameObject.GetComponent<ItemUpgradeVisualUI>();

        item = itemUpgradeVisualUI.itemTemp;

        itemManager.UpdateItem(item, itemUpgradeVisualUI.starLevel);

        upgradeTableItem.Hide();
        upgradeTableItem.ClearChoice();
        upgradeTableItem.GameContinue();
       

       
    }
}
