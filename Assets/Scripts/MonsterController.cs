using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
    // Monster status
    private int Health;


    PlayerController playerController;
    void Start() {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        Health = 10;
    }

    private void OnCollisionEnter( Collision collision ) {
        if (collision.gameObject.CompareTag("Player")) {

            playerController.PlayerDie();

        } else if (collision.gameObject.CompareTag("Arrow")) {

            ArrowController arrow = collision.gameObject.GetComponent<ArrowController>();

            if (arrow != null) {

                int arrowDamage = arrow.GetArrowDamage();
                DamageCalculation(arrowDamage);
            }

        } else if (collision.gameObject.CompareTag("Fireball")) {

            FireballController fireball = collision.gameObject.GetComponent<FireballController>();

            if (fireball != null) {

                int damage = fireball.GetFireBallDamage();
                DamageCalculation(damage);
            }

        } else {
            /* Debug.Log("False");*/
        }
    }
    private void OnTriggerEnter( Collider other ) {
        if (other.gameObject.CompareTag("Sword")) {

/*            Debug.Log(other.gameObject.name);*/

            SwordController sword = other.gameObject.GetComponent<SwordController>();

            if (sword != null) {
                int damage = sword.GetSwordDamage();
                DamageCalculation(damage);
                sword.AttackTarget();
            }  
            
         }
    }

    void DamageCalculation( int dmg ) {   

        Health -= dmg;

        Debug.Log(Health);
        if (Health <= 0) {
            MonsterDie();
        }
    }
    void MonsterDie() {
        Debug.Log("Monster died!");
        Destroy(gameObject);
    }
}
