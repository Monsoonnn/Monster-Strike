using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour {
    private GroundController groundController;
    private PlayerController playerController;
    [SerializeField] private GameObject monsterObj;
    [SerializeField] private Transform nextSpawnPoint;
    public float speed = 5f;
    private bool monsterSpawned = false;
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
            groundController.SpawnTile(groundController.GetNextSpawnPoint());
            Destroy(gameObject, 2);
        }
    }


    private void Update() {
        if (!playerController.IsPlayerAlive()) return;
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }


    private void SpawnMonster() {

        int monsterSpawnPointIndex = Random.Range(2, 5);

        Transform spawnPoint = transform.GetChild(monsterSpawnPointIndex).transform;

        Instantiate(monsterObj, spawnPoint.position, Quaternion.identity, transform);

    }

    public Transform GetSpawnPoint() {
        return nextSpawnPoint;
    }

    

}
