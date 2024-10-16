using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    // Player status
    private bool alive = true;
    private int health = 50;

    private float speed = 5;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform arrowSpawnPoint;

    [SerializeField] private GameObject sword;
    [SerializeField] private List<Transform> swordSpawnPoints;

    [SerializeField] private GameObject dragon;
    [SerializeField] private List<Transform> dragonSpawnPoints;

    float horizontalInput;
    public float horizontalMultipiler = 1;

    private float baseFrequency = 10f;

    ArrowController arrowController;
    SwordController swordController;
    DragonController dragonController;

    private int currentDragonCount;

    private float arrowFreqency;
    private float swordFreqency;
    private float dragonCount;

    private void Start() {

        currentDragonCount = 0;

        arrowController = arrow.gameObject.GetComponent<ArrowController>();
        arrowFreqency = arrowController.GetArrowFrequency();

        swordController = sword.gameObject.GetComponent<SwordController>();
        swordFreqency = swordController.GetSwordFrequency();

        dragonController = dragon.gameObject.GetComponent<DragonController>();
        dragonCount = dragonController.GetDragonCount();

        InvokeRepeating("SpawnArrow", 1f, arrowFreqency);
        InvokeRepeating("SpawnSword", 2f, swordFreqency);
        InvokeRepeating("SpawnDragon", 2.5f, baseFrequency);
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

        int swordCount = swordController.GetSwordCount();

        for (int i = 0; i < swordCount; i++) {
            int index = Random.Range(0, 2);
            Vector3 offset = new Vector3(Random.Range(0.5f, 1f), Random.Range(0.2f, 0.8f), Random.Range(0.5f, 1f));
            Instantiate(sword, swordSpawnPoints[index].position + offset, Quaternion.identity);
        } 

    }
    public void SpawnDragon() {
        if (currentDragonCount > dragonCount) {
            Debug.Log("Rồng đã đủ lớn để nâng cấp");
            return;
        } else {
            for (int i = 0; i < dragonCount; i++) {
                Transform spawnPoint = dragonSpawnPoints[i];
                Instantiate(dragon, spawnPoint.position, Quaternion.identity, transform);
                currentDragonCount++;
                if (currentDragonCount >= dragonCount) {
                    return;
                }
            }

        }

         


    }
}
