using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour {

    // Player status
    private bool alive = true;
    public float health;

    public float horizontalSpeed;


    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform arrowSpawnPoint;

    [SerializeField] private GameObject sword;
    [SerializeField] private List<Transform> swordSpawnPoints;

    [SerializeField] private GameObject dragon;
    [SerializeField] private List<Transform> dragonSpawnPoints;

    [SerializeField] private GameObject wolf;
    [SerializeField] private List<Transform> wolfSpawnPoints;

    [SerializeField] private BaseItem_Support impactBelt;



    public int levelBelt = 0;


    float horizontalInput;
    public float horizontalMultipiler = 1;

    private float baseFrenquency = 10f;

    ArrowController arrowController;
    SwordController swordController;
    DragonController dragonController;
    WolfController wolfController;

    private UIManager uiManager;
    [SerializeField] private GameOverUI gameOverUI;

    private int currentDragonCount;
    private int currentSwordCount;
    private int currentWolfCount;

    public int wolfCount;
    private int dragonCount;
    private int swordCount;

    private float currentArrowFrequency;
    private float currentSwordFrequency;

    private HashSet<Transform> spawnedDragonPoints = new HashSet<Transform>(); 

    private List<GameObject> currentWolfPrefab = new List<GameObject>();
    private void Start() {
        uiManager = GameObject.FindAnyObjectByType<UIManager>();
       
        InitItem(); 
        // Weapon item


        // Support Item
        levelBelt = impactBelt.level;

        currentArrowFrequency = 100f / arrowController.GetArrowFrequency();
        currentSwordFrequency = 100f / swordController.attackFrequency;

        InvokeRepeating("SpawnArrow", 0f, currentArrowFrequency);
        InvokeRepeating("SpawnSword", 2f, currentSwordFrequency);
        InvokeRepeating("SpawnDragon", 3f, baseFrenquency);
        InvokeRepeating("SpawnWolf", 3f, baseFrenquency);
    }
    private void FixedUpdate() {
        if (!alive) return;

        Vector3 horizontalMove = transform.right * horizontalInput * horizontalSpeed * Time.deltaTime * horizontalMultipiler;

        rb.MovePosition(rb.position + horizontalMove);
      
    }
    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5) {
            PlayerDie();
        }

       ItemUpdate();
       UpdateWolf();
    }
    public void ItemUpdate() {
        float arrowFrequency = 100f / arrowController.GetArrowFrequency();
        float swordFrequency = 100f / swordController.attackFrequency;
        if (currentArrowFrequency < arrowFrequency) {
            CancelInvoke("SpawnArrow");
            InvokeRepeating("SpawnArrow", 0f, arrowFrequency);
            currentArrowFrequency = arrowFrequency;
        }
        if (currentSwordFrequency < swordFrequency) {
            CancelInvoke("SpawnSword");
            InvokeRepeating("SpawnSword", 0f, swordFrequency);
            currentSwordFrequency = swordFrequency;
        }
       

        dragonCount = dragonController.GetDragonCount();
        swordCount = swordController.swordCount;
        wolfCount = wolfController.GetWolfCount();
    }
    public void PlayerDie() {
        alive = false;
        if (!uiManager.isGamePause) {
            gameOverUI.Toggle();
            uiManager.GamePause();
            uiManager.isGameOver = true;
           
        }
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

            
            GameObject swordObj = Instantiate(sword, spawnPoint.position + offset, Quaternion.identity);

            
            SwordController swordScript = swordObj.GetComponent<SwordController>();
            if (swordScript != null) {
                swordScript.SetSpawnPoint(spawnPoint);
            }

            currentSwordCount++;
        }

    }
    public void SpawnDragon() {
        if (currentDragonCount >= 3) {
            Debug.Log("Rồng đã đủ lớn để nâng cấp");
            return;
        }
        foreach (Transform spawnPoint in dragonSpawnPoints) {
            // Kiểm tra nếu đã đạt giới hạn số lượng rồng thì dừng lại
            if (currentDragonCount >= dragonCount) {
                break;
            }

            // Kiểm tra nếu vị trí này đã spawn rồi thì bỏ qua
            if (spawnedDragonPoints.Contains(spawnPoint)) {
                continue;
            }

            // Spawn rồng và thêm vị trí vào danh sách đã spawn
            Instantiate(dragon, spawnPoint.position, Quaternion.identity, transform);
            spawnedDragonPoints.Add(spawnPoint);
            currentDragonCount++;

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

            currentWolfPrefab.Add(wolfInstance);

            // Gán spawnPoint vào script Wolf của đối tượng wolfInstance
            WolfController wolfScript = wolfInstance.GetComponent<WolfController>();
            if (wolfScript != null) {
                wolfScript.SetSpawnPoint(spawnPoint);
            }

            // Tăng số lượng sói đã spawn
            currentWolfCount++;
        }
    }



    public float GetPlayerHealth() {
        return health;
    }
    public void SetPlayerHealth (float monsterHealth) {
       

        int reduceHealth = impactBelt.reduceDamage(monsterHealth, levelBelt);

        health = health - reduceHealth;
        
        Debug.Log("Reduce Impact: " + reduceHealth);

        Debug.Log("Player health: " + health);
    }



    public void SetCurrentSwordCount() { 
        currentSwordCount--;
    }

    public void SetCurrentWolfCount() {
        currentSwordCount--;
    }

    public bool HasImpactBelt() {
        if (levelBelt > 0) {
            return true;
        }
        return false;
    }


    public void InitItem() {
        arrowController = arrow.gameObject.GetComponent<ArrowController>();
        swordController = sword.gameObject.GetComponent<SwordController>();
        dragonController = dragon.gameObject.GetComponent<DragonController>();
        wolfController = wolf.gameObject.GetComponent<WolfController>();

        arrowController.InitializeArrowProperties(); // Lấy thông tin từ prefab ScriptableObj
        swordController.InitializeSwordProperties();
        wolfController.InitializeWolfProperties();


        currentDragonCount = 0;
        currentSwordCount = 0;
        currentWolfCount = 0;
        dragonCount = dragonController.GetDragonCount();
        swordCount = swordController.swordCount;
        wolfCount = wolfController.GetWolfCount();

       

    }


    public void UpdateWolf() {

        if (wolfController.maxCount >= 4) {
            currentWolfCount = 0;
            wolfController.maxCount = 1;
            wolfController.level++;
            DestroyAllWolves();
        }

    }

    public void DestroyAllWolves() {

        for (int i = currentWolfPrefab.Count - 1; i >= 0; i--) {
            Destroy(currentWolfPrefab[i]);
            currentWolfPrefab.RemoveAt(i);
            SetCurrentWolfCount();
        }
    }
}
