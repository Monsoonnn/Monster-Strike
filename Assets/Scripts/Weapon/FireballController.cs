using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float speed;
    public int damage;
    public float maxDistance; // khoang cach xa nhat cau lua di duoc
    public float attackDistance; // khoang cach tim kiem muc tieu
    public float frequency;


    private Vector3 startPosition;
    private Vector3 endPosition;

    private Transform targetMonster = null;
    private bool isFindAMonster = false;

    void Start() {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0,0,maxDistance);
    }

    void Update() {
        if (transform.position.z > (endPosition.z)) {
            AttackTarget();
        }

        if (!isFindAMonster ) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            FindTarget();
        }
        if (isFindAMonster && targetMonster != null) { 
            MoveToTarget();
        }
        if (isFindAMonster && targetMonster == null) {
            //Kiểm tra nếu quái chết trước khi kiếm đến
            Debug.Log("Monster has been killed");
            Destroy(gameObject);
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
        if (targetMonster == null) { Destroy(gameObject);  return; }
        Vector3 direction = (targetMonster.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
        transform.Translate(direction * speed * Time.deltaTime);

    }


    public void AttackTarget() {
        Destroy(gameObject);
    }

    public int GetFireBallDamage() {
        return damage;
    }

    public float GetFireBallFrequency() { return frequency; }
}
