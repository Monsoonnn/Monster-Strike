using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterReward_Script : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject rewardChestObj;

    public void SpawnRewardChest() { 
        Instantiate(rewardChestObj, spawnPoint.position, Quaternion.identity, transform.parent.parent);
    }
}
