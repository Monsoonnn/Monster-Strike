using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwordController : MonoBehaviour {



    [SerializeField] private BaseItem prefab;

    public float attackDistance;  // Khoảng cách tấn công
    public float moveSpeed;      // Tốc độ di chuyển của kiếm
    public float attackFrequency; // Thời gian respawn của kiếm 
    public int swordCount;       // Số lượng kiếm có thể spawn
    public float damage;             // Sát thương của kiếm
    public int level;
    private bool isAttacking = false;   // Biến kiểm soát trạng thái tấn công

    private Transform targetMonster = null;

    private Transform spawnPoint; // vi tri spawn

    private bool isPlayingSound = false;

    PlayerController playerController;
    void Start() {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update() {

        if (!isAttacking) {
            //Tìm quái và cho kiếm follow nhân vật
            FindTarget();
            FollowPlayer();
        }

        if (isAttacking && targetMonster != null) {

            MoveToTarget(); // Di chuyển tới quái vật

        }
        if (isAttacking && targetMonster == null) {
            //Kiểm tra nếu quái chết trước khi kiếm đến
            Debug.Log("Monster has been killed");
            isPlayingSound = false;
            AttackTarget();
        }

    }

    void FindTarget() {
        // Lấy tất cả các đối tượng trong vùng bán kính xung quanh kiếm
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward * attackDistance * 0.5f, attackDistance * 0.5f);


        foreach (Collider collider in hitColliders) {
            if (collider.CompareTag("Monster")) {
                targetMonster = collider.transform;
                isAttacking = true;
                /*               Debug.Log("Found monster: " + collider.gameObject.name);*/
                break;
            }
        }

        if (targetMonster == null) {
            /*  Debug.Log("No monster found in range.");*/
        }
    }

    void MoveToTarget() {
        //Di chuyển kiếm tới quái vật
        
        Vector3 direction = (targetMonster.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);

        transform.Translate(direction * moveSpeed * Time.deltaTime);

    }


    public void AttackTarget() {
        playerController.SetCurrentSwordCount();
        Destroy(gameObject);
    }

    void FollowPlayer() {
        float distance = Vector3.Distance(transform.position, spawnPoint.transform.position);
        float followSpeed = 5f;
        if (distance >= 2f) {
            Vector3 offset = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 0.8f), Random.Range(0.5f, 1.5f));
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint.transform.position + offset, followSpeed * Time.deltaTime);
        }

    }


    public void SetSpawnPoint( Transform point ) {
        spawnPoint = point;
    }

    public void InitializeSwordProperties() {
        attackDistance = prefab.attackDistance;
        moveSpeed = prefab.speed;
        level = prefab.level;

        damage = prefab.damageByLevel[level];
        attackFrequency = prefab.frequencyByLevel[level];
        swordCount = (int)prefab.countByLevel[level];
    }

}
