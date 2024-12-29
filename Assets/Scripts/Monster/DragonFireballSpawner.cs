using System.Collections.Generic;
using UnityEngine;

public class DragonFireballSpawner : MonoBehaviour {
    [SerializeField] private GameObject fireballObj;
    [SerializeField] private List<Transform> spawnPoints;

    private float spawnInterval = 3f;
    private bool shouldSpawn = true; 

    public void SpawnFireballsInOrder() {
        int[] spawnOrderIfTrue = { 0, 2, 4 };
        int[] spawnOrderIfFalse = { 1, 3 };

        SetSpawnFlag(!shouldSpawn);


        int[] selectedOrder = shouldSpawn ? spawnOrderIfTrue : spawnOrderIfFalse;

        foreach (int index in selectedOrder) {
            if (index < spawnPoints.Count) {
                Transform spawnPoint = spawnPoints[index];
                if (spawnPoint != null) {
                    Instantiate(fireballObj, spawnPoint.position, spawnPoint.rotation);
                }
               
            }
        }
    }

    public void SetSpawnFlag( bool flag ) {
        shouldSpawn = flag;
    }

    private void Start() {
        InvokeRepeating(nameof(SpawnFireballsInOrder), 0f, spawnInterval);
    }
}