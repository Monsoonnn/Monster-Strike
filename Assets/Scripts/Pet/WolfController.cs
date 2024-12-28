using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WolfController : MonoBehaviour {



    [SerializeField] private BaseItem wolf;

    public int damage;
    public float speed;

    public float attackDistance; // khoang cach tim kiem muc tieu
    public int maxCount; // So luong neu la 4 thi levelUp
    public int level;


    private Transform targetMonster = null;

    private bool isFindAMonster = false;
    public bool isNearMonster { get; private set; }
    public bool isFinishedAttack { get; set; }

    public bool isLevelUp = false;

    private Transform spawnPoint; // vi tri spawn

    PlayerController player;
    void Start() {
        player = GameObject.FindObjectOfType<PlayerController>();
       
    }

    void Update() {

        CheckWolfStats();
        CheckDistanceAndReturn();

        if (!isFindAMonster) {
            FollowPlayer();
            FindTarget();
        }
        if (isFindAMonster && targetMonster != null) {
           
            MoveToTarget();
        }
        if (isFindAMonster && targetMonster == null) {
            //Kiểm tra nếu quái chết trước khi kiếm đến
            /* Debug.Log("Monster has been killed");*/
            BackToPlayer();
        }


    }
    private void CheckDistanceAndReturn() {
        // Kiểm tra khoảng cách giữa player và wolf
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Nếu khoảng cách lớn hơn 10f, gọi hàm BackToPlayer
        if (distance > 20f) {
            BackToPlayer();
        }
    }
    void FindTarget() {
        // Lấy tất cả các đối tượng trong vùng bán kính xung quanh kiếm
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward * attackDistance * 0.5f, attackDistance * 0.5f);

       
        foreach (Collider collider in hitColliders) {
            if (collider.CompareTag("Monster")) {
                targetMonster = collider.transform;
                isFindAMonster = true;
                /*Debug.Log("Found monster: " + collider.gameObject.name);*/
                break;
            }
        }

        if (targetMonster == null) {
            /*      Destroy(gameObject);*/
        }


    }

    void MoveToTarget() {
        //Di chuyển kiếm tới quái vật
        float distanceToTarget = Vector3.Distance(transform.position, targetMonster.position);
       

        // Kiểm tra nếu khoảng cách hiện tại lớn hơn khoảng cách mong muốn ( đơn vị trục z)
        if (distanceToTarget > 0.1f) {

            Vector3 direction = (targetMonster.position - transform.position).normalized;


            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);

            //  không thay đổi vị trí y
            Vector3 newPosition = transform.position + new Vector3(direction.x, 0, direction.z) * speed * Time.deltaTime;
            transform.position = newPosition;

            isNearMonster = true;

            

        } else {

           
            // Có thể thực hiện các hành động khác nếu cần khi kiếm ở gần quái vật
            // Debug.Log("Đã vào vị trí");
        }


    }

    void FollowPlayer() {
        float distance = Vector3.Distance(transform.position, spawnPoint.transform.position);
        float followSpeed = 5f;
        if (distance >= 2f) {
            Vector3 offset = new Vector3(Random.Range(0.5f, 1.5f), 0f, Random.Range(0.5f, 1.5f));
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint.transform.position + offset, followSpeed * Time.deltaTime);
        }

    }

    public void AttackTarget() {
        Destroy(gameObject);
    }
    public void BackToPlayer() {
        transform.position = spawnPoint.transform.position;
        transform.rotation = Quaternion.identity;
        isFindAMonster = false;
        targetMonster = null;
        isNearMonster = false;
        isFinishedAttack = false;
    }


    public int GetWolfDamage() {
        return damage;
    }

    public int GetWolfCount() { return maxCount; }

    public void LevelUp() { level++; }


    public void SetSpawnPoint( Transform point ) {
        spawnPoint = point;
    }

    public int GetDamage() { return damage; }



    public void InitializeWolfProperties() {
        speed = wolf.speed;
       
        attackDistance = wolf.attackDistance;
        if (isLevelUp) {
            isLevelUp = false;
        } else {
            level = wolf.level;
        }

        damage = (int)wolf.damageByLevel[level];
        maxCount = (int)wolf.countByLevel[level];

    }

    public void CheckWolfStats() {

        damage = (int)wolf.damageByLevel[level];
 
    }

   
}
