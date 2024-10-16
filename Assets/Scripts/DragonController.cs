using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    // Về sau thay thế bằng scriptableObj
    // Cmt bên cạnh là gpt viết hộ

    public int dragonCount;         


    private PlayerController player;
    [SerializeField] private Transform fireballSpawnPoint;
    [SerializeField] private GameObject fireball; 

    FireballController fireballController;

    private void Start() {
        player = GameObject.FindObjectOfType<PlayerController>();
        fireballController = fireball.gameObject.GetComponent<FireballController>();
        float fireballFrequency = fireballController.GetFireBallFrequency();

        InvokeRepeating("SpawnFireBall", 1f, fireballFrequency);
    }
    void Update() {
            FollowPlayer();
    }


    void FollowPlayer() {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float followSpeed = 3f;
        if (distance >= 1.5f) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }

    }
    public void SpawnFireBall() {
        Instantiate(fireball, fireballSpawnPoint.position, Quaternion.identity);
    }

    public int GetDragonCount() { 
        return dragonCount;
    }
}
