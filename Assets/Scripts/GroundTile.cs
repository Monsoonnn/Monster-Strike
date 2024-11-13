using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour {
    private GroundController groundController;
    private PlayerController playerController;
    [SerializeField] private GameObject monsterObj;
    [SerializeField] private GameObject smallBossObj;
    [SerializeField] private Transform nextSpawnPoint;

    [SerializeField] private List<Transform> listSpawnPoint;
    [SerializeField] private Transform bossSpawnPoint;

    List<int> spawnedIndexes = new List<int>();

    public float speed;
    private bool monsterSpawned = false;
    public bool bossSpawned = false;
    private int totalEnemiesToSpawn;
    private bool isDoubleMonster = false;
    private Vector3 offset = new Vector3(0, 0, 95);

    void Start() {
        groundController = GameObject.FindObjectOfType<GroundController>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        if (!monsterSpawned) {
            SpawnMonster();  
            monsterSpawned = true;
        } 
    }

    private void FixedUpdate() {
        if (bossSpawned) {
            Instantiate(smallBossObj, bossSpawnPoint.position, Quaternion.identity, transform);
            bossSpawned = false ;
        }
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

    private void Update() {
        if (!playerController.IsPlayerAlive()) return;
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }


    private void SpawnMonster() {

        totalEnemiesToSpawn = listSpawnPoint.Count / 2;


        // Duyệt qua danh sách và spawn quái.
        for (int i = 0; i < totalEnemiesToSpawn * 2; i += 2) {
            Transform spawnPoint = listSpawnPoint[i];

            // Lấy child "left" và "right" của spawnPoint
            Transform leftSpawn = spawnPoint.transform.GetChild(0);
            Transform rightSpawn = spawnPoint.transform.GetChild(1);

            // Chọn ngẫu nhiên giữa left và right để spawn quái
            Transform selectedSpawnPoint = (Random.value > 0.5f) ? leftSpawn : rightSpawn;

            Instantiate(monsterObj, selectedSpawnPoint.position, Quaternion.identity, transform);

            // Đánh dấu vị trí đã spawn
            spawnedIndexes.Add(i);
        }

       


    }

    public void SpawnDoubleMonster() {

        if (isDoubleMonster) { return; }

        int additionalEnemiesToSpawn = totalEnemiesToSpawn;
        for (int i = 1; i < listSpawnPoint.Count && additionalEnemiesToSpawn > 0; i += 2) {
            // Kiểm tra nếu vị trí chưa được spawn và không phải là vị trí boss
            if (!spawnedIndexes.Contains(i) && listSpawnPoint[i] != listSpawnPoint[listSpawnPoint.Count - 1]) {
                Transform spawnPoint = listSpawnPoint[i];

                // Lấy child "left" và "right" của spawnPoint
                Transform leftSpawn = spawnPoint.transform.GetChild(0);
                Transform rightSpawn = spawnPoint.transform.GetChild(1);

                // Chọn ngẫu nhiên giữa left và right để spawn quái
                Transform selectedSpawnPoint = (Random.value > 0.5f) ? leftSpawn : rightSpawn;

                Instantiate(monsterObj, selectedSpawnPoint.position, Quaternion.identity, transform);

                additionalEnemiesToSpawn--;
            }
        }
        isDoubleMonster = true;
    }

    

}
