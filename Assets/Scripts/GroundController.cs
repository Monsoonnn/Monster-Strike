using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private GameObject groundTile;
    public Vector3 nextSpawnPoint { set; get; }

    public int round;
    public int turn; // 3 turn = 1 round;

    private GroundTile currentTitle;

    void Awake()
    {
        Vector3 startOffSet = new Vector3(0, 0, 8);
        for (int i = 0; i < 2; i++) {
            SpawnTile(nextSpawnPoint);
        }
    }


    public void SpawnTile( Vector3 nextSpawnPlanePoint ) {

        updateTurn();
        
        GameObject temp = Instantiate(groundTile, nextSpawnPlanePoint, Quaternion.identity);


        GroundTile tileTemp = temp.gameObject.GetComponent<GroundTile>();

        nextSpawnPoint = temp.transform.GetChild(0).transform.position;


        if (turn == 3) {
            tileTemp.bossSpawned = true;
            turn = 0;
        }
    }

    public void updateTurn() { 
        turn++;
        if (turn == 3) {
            round++;
        }
    }

    public void DoubleMonsterCurrentTitle() { 
       currentTitle.SpawnDoubleMonster();
    }

    public void setCurrentTile(GroundTile tile) {
        currentTitle = tile;
    }



}
