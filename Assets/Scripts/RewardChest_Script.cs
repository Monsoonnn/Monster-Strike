using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RewardChest_Script : MonoBehaviour
{

    private GameObject UIManagaer;
    private GameObject UIupgradeItem;

    private void Start() {
        UIManagaer = GameObject.FindGameObjectWithTag("UIManager");

        UIupgradeItem = UIManagaer.transform.GetChild(0).gameObject;


    }


    private void OnTriggerEnter( Collider other ) {
        if (other.gameObject.CompareTag("Player")) {
           
            UI_UpgradeItem upgradeTable = UIupgradeItem.GetComponent<UI_UpgradeItem>();

            upgradeTable.Show();
            upgradeTable.ShowItem();
            upgradeTable.GamePause();

        }
    }

    private void OnTriggerExit( Collider other ) {
        if (other.gameObject.CompareTag("Player")) {

            Destroy(gameObject);

        }
    }




}
