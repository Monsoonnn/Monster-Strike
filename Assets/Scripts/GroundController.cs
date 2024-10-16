using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private GameObject groundTile;
    public Vector3 nextSpawnPoint;
    public Vector3 offset = new Vector3 (0,0,28);
    
    void Awake()
    {
        for (int i = 0; i < 5; i++) {
            SpawnTile(nextSpawnPoint);
        }
    }


    public void SpawnTile( Vector3 nextSpawnPlanePoint ) { 
        GameObject temp = Instantiate(groundTile, nextSpawnPlanePoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    public Vector3 GetNextSpawnPoint() { 
        return nextSpawnPoint - offset;
    }

}
