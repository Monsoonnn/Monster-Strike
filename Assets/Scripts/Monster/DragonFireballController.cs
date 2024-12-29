using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonFireballController : MonoBehaviour {
    public int monsterHealth;
    private float speed = 25f; // Speed of the fireball

    private PlayerController playerController;
    private bool isDamaged = false;

    void Start() {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update() {
        
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        
        if (transform.position.z <= -5) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter( Collider other ) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Damage duoc nhan tu: " + other.gameObject.name);

            DamageToPlayer();
        }
    }


    void DamageToPlayer() {

        if (isDamaged) return;

        if (!playerController.IsPlayerAlive()) {
            playerController.PlayerDie();
            return;
        }  // Nhan vat con song ko ?

        float playerHealth = playerController.GetPlayerHealth();

        if (playerHealth <= monsterHealth) {
            playerController.PlayerDie();
            Destroy(gameObject);
            return;
        } else {
            playerController.SetPlayerHealth(monsterHealth);
            Destroy(gameObject);
        }
        isDamaged = true;
    }
}