using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private GameObject groundTile;
    public Vector3 nextSpawnPoint { set; get; }  
    void Awake()
    {
        Vector3 startOffSet = new Vector3(0, 0, 8);
        for (int i = 0; i < 2; i++) {
            SpawnTile(nextSpawnPoint);
        }
    }


    public void SpawnTile( Vector3 nextSpawnPlanePoint ) { 
        GameObject temp = Instantiate(groundTile, nextSpawnPlanePoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }



}
