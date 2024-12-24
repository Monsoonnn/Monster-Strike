using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RewardChest_DropItem : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject rewardChestObj;
    [SerializeField] private RandomDropItem rndItem;
    public void SpawnRewardChest() {

        GameObject newPrefab = Instantiate(rewardChestObj, spawnPoint.position, Quaternion.identity, transform.parent.parent);

        RewardDropChest rewardDropChest = newPrefab.GetComponent<RewardDropChest>();

        rewardDropChest.GetDropItemStats(rndItem.GetRandomDropItem());
    }
}
