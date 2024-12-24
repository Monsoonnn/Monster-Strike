using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RewardChest_Script : MonoBehaviour
{

    private GameObject UIManagaer;
    private GameObject UIupgradeItem;
    private UIManager manager;

    private void Start() {
        UIManagaer = GameObject.FindGameObjectWithTag("UIManager");

        UIupgradeItem = UIManagaer.transform.GetChild(0).gameObject;

        manager = GameObject.FindObjectOfType<UIManager>();

    }


    private void OnTriggerEnter( Collider other ) {
        if (other.gameObject.CompareTag("Player")) {
           
            UI_UpgradeItem upgradeTable = UIupgradeItem.GetComponent<UI_UpgradeItem>();

            upgradeTable.Show();
            upgradeTable.ShowItem();
            if (!manager.isGamePause) { 
                manager.GamePause();
                manager.isPickingItem = true;
            }

        }
    }

    private void OnTriggerExit( Collider other ) {
        if (other.gameObject.CompareTag("Player")) {

            Destroy(gameObject);

        }
    }




}
