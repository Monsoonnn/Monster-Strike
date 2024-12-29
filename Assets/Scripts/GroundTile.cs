using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour {
    private GroundController groundController;
    private PlayerController playerController;

    [SerializeField] private GameObject monsterObj;
    [SerializeField] private GameObject smallBossObj;
    [SerializeField] private GameObject roundBossObj;
    [SerializeField] private Transform nextSpawnPoint;

    [SerializeField] private List<Transform> listSpawnPoint;
    [SerializeField] private Transform bossSpawnPoint;

    List<int> spawnedIndexes = new List<int>();
    public bool bossSmallSpawned = false;
    public bool bossRoundSpawned = false;
    private bool monsterSpawned = false;
    private bool isDoubleMonster = false;
    private Vector3 offset = new Vector3(0, 0, 95);

    public int monsterHealthScale;

    void Start() {
        groundController = GameObject.FindObjectOfType<GroundController>();
        playerController = GameObject.FindObjectOfType<PlayerController>();

        if (!monsterSpawned) {
            SpawnMonster();
            monsterSpawned = true;
        }
    }

    private void FixedUpdate() {
        if (bossSmallSpawned && !bossRoundSpawned) {
            GameObject monster = Instantiate(smallBossObj, bossSpawnPoint.position, Quaternion.identity, transform);

            MonsterController monsterController = monster.GetComponent<MonsterController>();

            float scaleRandom = Random.Range(10, 20);

            monsterController.SetHealth(monsterHealthScale * (int)scaleRandom);

            bossSmallSpawned = false;
        }
        if (bossRoundSpawned && !bossSmallSpawned) {
            GameObject monster = Instantiate(roundBossObj, bossSpawnPoint.position, Quaternion.identity, transform);

            MonsterController monsterController = monster.GetComponent<MonsterController>();

            float scaleRandom = Random.Range(10, 20);

            monsterController.SetHealth(monsterHealthScale * (int)scaleRandom);

            bossRoundSpawned = false;
        }
    }

    private void Update() {
        if (!playerController.IsPlayerAlive()) return;

        // Sử dụng tốc độ từ GroundController
        float currentSpeed = groundController.GetSpeed();
        transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerExit( Collider other ) {
        if (other.CompareTag("Player")) {
            groundController.SpawnTile(nextSpawnPoint.transform.position + offset);
            Destroy(gameObject, 2);
        }
    }

    private void OnTriggerEnter( Collider other ) {
        if (other.CompareTag("Player")) {
            groundController.setCurrentTile(this);
        }
    }

    private void SpawnMonster() {
        int totalEnemiesToSpawn = listSpawnPoint.Count / 2;

        for (int i = 0; i < totalEnemiesToSpawn * 2; i += 2) {
            Transform spawnPoint = listSpawnPoint[i];
            Transform leftSpawn = spawnPoint.transform.GetChild(0);
            Transform rightSpawn = spawnPoint.transform.GetChild(1);

            Transform selectedSpawnPoint = (Random.value > 0.5f) ? leftSpawn : rightSpawn;

            GameObject monster = Instantiate(monsterObj, selectedSpawnPoint.position, Quaternion.identity, transform);

            MonsterController monsterController = monster.GetComponent<MonsterController>();

            float scaleRandom = Random.Range(10, 30);

            monsterController.SetHealth(monsterHealthScale * (int)scaleRandom);

            spawnedIndexes.Add(i);
        }
    }

    public void SpawnDoubleMonster() {
        if (isDoubleMonster) return;

        int totalEnemiesToSpawn = listSpawnPoint.Count / 2;
        for (int i = 1; i < listSpawnPoint.Count && totalEnemiesToSpawn > 0; i += 2) {
            if (!spawnedIndexes.Contains(i) && listSpawnPoint[i] != listSpawnPoint[listSpawnPoint.Count - 1]) {
                Transform spawnPoint = listSpawnPoint[i];
                Transform leftSpawn = spawnPoint.transform.GetChild(0);
                Transform rightSpawn = spawnPoint.transform.GetChild(1);

                // Chọn ngẫu nhiên giữa left và right để spawn quái
                Transform selectedSpawnPoint = (Random.value > 0.5f) ? leftSpawn : rightSpawn;

                GameObject monster = Instantiate(monsterObj, selectedSpawnPoint.position, Quaternion.identity, transform);

                // Random máu cho quái
                MonsterController monsterController = monster.GetComponent<MonsterController>();
                float scaleRandom = Random.Range(10, 40);
                monsterController.SetHealth(monsterHealthScale * (int)scaleRandom);

                totalEnemiesToSpawn--;
            }
        }
        isDoubleMonster = true;
    }

}
