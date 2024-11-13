using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnPortal : MonoBehaviour
{
    [SerializeField] private List<Transform> listSpawnPortal;
    [SerializeField] private GameObject PortalPrefab;
    [SerializeField] private RandomDropItem rndItem;
    private List<DropItemType> listDropItemType = new List<DropItemType>();
    private void Start() {
        SpawnPortal();
        GetDropItemType();
    }


    private void SpawnPortal() {
        foreach (Transform transform in listSpawnPortal) {

            // Lấy child "left" và "right" của spawnPoint
            Transform leftSpawn = transform.transform.GetChild(0);
            Transform rightSpawn = transform.transform.GetChild(1);

            InstantiatePortal(PortalPrefab, leftSpawn);

            InstantiatePortal(PortalPrefab, rightSpawn);

        }
    }

    private void GetDropItemType() {


    }
    private void InstantiatePortal(GameObject prefab, Transform positon) {

        GameObject newPrefab = Instantiate(prefab, positon.position, Quaternion.identity, transform.parent);

        RewardPortal rewardPortal = newPrefab.GetComponent<RewardPortal>();

        rewardPortal.GetDropItemStats(rndItem.GetRandomDropItem());


    }



}
