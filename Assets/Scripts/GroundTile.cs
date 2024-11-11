using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour {
    private GroundController groundController;
    private PlayerController playerController;
    [SerializeField] private GameObject monsterObj;
    [SerializeField] private Transform nextSpawnPoint;
    private float speed = 15f;
    private bool monsterSpawned = false;

    private Vector3 offset = new Vector3(0, 0, 95);

    void Start() {
        groundController = GameObject.FindObjectOfType<GroundController>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        if (!monsterSpawned) {
            SpawnMonster();
            monsterSpawned = true;
        }

    }

    private void OnTriggerExit( Collider other ) {
        if (other.CompareTag("Player")) {
            groundController.SpawnTile(nextSpawnPoint.transform.position + offset);
            Destroy(gameObject, 2);
        }
    }


    private void Update() {
        if (!playerController.IsPlayerAlive()) return;
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }


    private void SpawnMonster() {

        int monsterSpawnPointIndex = Random.Range(1, 3);

        Transform spawnPoint = transform.GetChild(monsterSpawnPointIndex).transform;

        Instantiate(monsterObj, spawnPoint.position, Quaternion.identity, transform);

    }


    

}
