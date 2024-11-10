using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour {

    // Player status
    private bool alive = true;
    public int health = 50;

    private float speed = 5;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform arrowSpawnPoint;

    [SerializeField] private GameObject sword;
    [SerializeField] private List<Transform> swordSpawnPoints;

    [SerializeField] private GameObject dragon;
    [SerializeField] private List<Transform> dragonSpawnPoints;

    [SerializeField] private GameObject wolf;
    [SerializeField] private List<Transform> wolfSpawnPoints;

    float horizontalInput;
    public float horizontalMultipiler = 1;

    private float baseFrenquency = 10f;

    ArrowController arrowController;
    SwordController swordController;
    DragonController dragonController;
    WolfController wolfController;

    private int currentDragonCount;
    private int currentSwordCount;
    private int currentWolfCount;

    private int wolfCount;
    private int dragonCount;
    private int swordCount;


    private HashSet<Transform> spawnedDragonPoints = new HashSet<Transform>(); // Tập lưu các vị trí đã spawn rồng
    private HashSet<Transform> spawnedWolfPoints = new HashSet<Transform>(); // Tập lưu các vị trí đã spawn sói

    private void Start() {

        arrowController = arrow.gameObject.GetComponent<ArrowController>();
        swordController = sword.gameObject.GetComponent<SwordController>();
        dragonController = dragon.gameObject.GetComponent<DragonController>();
        wolfController = wolf.gameObject.GetComponent<WolfController>();

        arrowController.InitializeArrowProperties();
        swordController.InitializeSwordProperties();


        currentDragonCount = 0;
        currentSwordCount = 0;
        currentWolfCount = 0;
        dragonCount = dragonController.GetDragonCount();
        swordCount = swordController.swordCount;
        wolfCount = wolfController.GetWolfCount();

        float arrowFrequency = 100f / arrowController.GetArrowFrequency();
        float swordFrequency = 100f / swordController.attackFrequency;



        InvokeRepeating("SpawnArrow", 0f, arrowFrequency);
        InvokeRepeating("SpawnSword", 2f, swordFrequency);
        InvokeRepeating("SpawnDragon", 3f, baseFrenquency);
        InvokeRepeating("SpawnWolf", 3f, baseFrenquency);
    }
    private void FixedUpdate() {
        if (!alive) return;

        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.deltaTime * horizontalMultipiler;

        rb.MovePosition(rb.position + horizontalMove);
    }
    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5) {
            PlayerDie();
        }
        
    }

    public void PlayerDie() {
        alive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public bool IsPlayerAlive() {
        return alive;
    }

    public void SpawnArrow() {
        Instantiate(arrow, arrowSpawnPoint.position, Quaternion.identity);
    }

    public void SpawnSword() {

        foreach (Transform spawnPoint in swordSpawnPoints) {
            if (currentSwordCount >= swordCount) {
                break;
            }
            Vector3 offset = new Vector3(Random.Range(0.5f, 1f), Random.Range(0.2f, 0.8f), 0f);

            // Spawn kiem
            GameObject swordObj = Instantiate(sword, spawnPoint.position + offset, Quaternion.identity);

            // Gán spawnPoint vào script Wolf của đối tượng wolfInstance
            SwordController swordScript = swordObj.GetComponent<SwordController>();
            if (swordScript != null) {
                swordScript.SetSpawnPoint(spawnPoint);
            }

            // Tăng số lượng sói đã spawn
            currentSwordCount++;
        }

    }
    public void SpawnDragon() {
        if (currentDragonCount > dragonCount) {
            Debug.Log("Rồng đã đủ lớn để nâng cấp");
            return;
        }
        foreach (Transform spawnPoint in dragonSpawnPoints) {
            // Kiểm tra nếu vị trí này đã spawn rồi thì bỏ qua
            if (spawnedDragonPoints.Contains(spawnPoint)) {
                continue;
            }

            // Spawn rồng và thêm vị trí vào danh sách đã spawn
            Instantiate(dragon, spawnPoint.position, Quaternion.identity, transform);
            spawnedDragonPoints.Add(spawnPoint);
            currentDragonCount++;

            // Kiểm tra nếu đã đạt giới hạn số lượng rồng thì dừng lại
            if (currentDragonCount >= dragonCount) {
                break;
            }
        }

    }

    public void SpawnWolf() {
        foreach (Transform spawnPoint in wolfSpawnPoints) {
            if (currentWolfCount >= wolfCount) {
                break;
            }
            Vector3 offset = new Vector3(Random.Range(0.5f, 1f), 0f, 0f);

            // Spawn sói tại vị trí spawnPoint với offset
            GameObject wolfInstance = Instantiate(wolf, spawnPoint.position + offset, Quaternion.identity);

            // Gán spawnPoint vào script Wolf của đối tượng wolfInstance
            WolfController wolfScript = wolfInstance.GetComponent<WolfController>();
            if (wolfScript != null) {
                wolfScript.SetSpawnPoint(spawnPoint);
            }

            // Tăng số lượng sói đã spawn
            currentWolfCount++;
        }
    }



    public int GetPlayerHealth() {
        return health;
    }
    public void SetPlayerHealth (int monsterHealth) {
       
        health = health - monsterHealth;
        Debug.Log("Player health: " + health);
    }



    public void SetCurrentSwordCount() { 
        currentSwordCount--;
    }
}
