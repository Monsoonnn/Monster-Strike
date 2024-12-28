using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {
    [SerializeField] private GameObject groundTile;
    public Vector3 nextSpawnPoint { set; get; }

    public int round;
    public int turn; // 3 turn = 1 round;

    public float speed = 8f; // Tốc độ ban đầu
    private int currentScaleHealth = 0;

    private GroundTile currentTile;

    void Awake() {
        Vector3 startOffset = new Vector3(0, 0, 8);
        for (int i = 0; i < 2; i++) {
            SpawnTile(nextSpawnPoint);
        }
    }

    public void SpawnTile(Vector3 nextSpawnPlanePoint) {
        updateTurn();

        GameObject temp = Instantiate(groundTile, nextSpawnPlanePoint, Quaternion.identity);
        GroundTile tileTemp = temp.GetComponent<GroundTile>();
        tileTemp.monsterHealthScale = currentScaleHealth;

        nextSpawnPoint = temp.transform.GetChild(0).position;

        if (turn == 2) {
            tileTemp.bossSpawned = true;
            turn = 0;

            if (speed < 15f) {
                IncreaseSpeed(0.5f);
            }
            if (speed > 15f && speed < 20f) {
                IncreaseSpeed(0.25f);
            }
            
        }
    }

    public void updateTurn() {
        turn++;
        if (turn == 2) {
            round++;
            currentScaleHealth += 1;
        }
    }

    public void IncreaseSpeed(float amount) {
        speed += amount;
    }

    public float GetSpeed() {
        return speed;
    }

    public void DoubleMonsterCurrentTile() {
        currentTile.SpawnDoubleMonster();
    }

    public void setCurrentTile(GroundTile tile) {
        currentTile = tile;
    }
}
