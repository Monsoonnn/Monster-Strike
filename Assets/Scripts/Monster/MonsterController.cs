using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
    // Monster status
    private int monsterHealth = 10;


    PlayerController playerController;

    [SerializeField] private MonsterReward_Script monsterReward;

    


    void Start() {
        playerController = GameObject.FindObjectOfType<PlayerController>();
   
    }

    private void OnCollisionEnter( Collision collision ) {
        if (collision.gameObject.CompareTag("Player")) {

            DamageToPlayer();

        } 
        if (collision.gameObject.CompareTag("Arrow")) {

            ArrowController arrow = collision.gameObject.GetComponent<ArrowController>();

            if (arrow != null) {

                int arrowDamage = arrow.GetArrowDamage();
                DamageCalculation(arrowDamage);
            }

        }
        if (collision.gameObject.CompareTag("Wolf")) {

           

            WolfController wolf = collision.gameObject.GetComponent<WolfController>();
 
            if (wolf != null ) {
                if (wolf.isFinishedAttack) {
                  /*  Debug.Log("Damage duoc nhan tu: " + collision.gameObject.name);*/
                    int wolfDamage = wolf.GetDamage();
                    DamageCalculation(wolfDamage);
                    wolf.isFinishedAttack = false;
                }
               
            }

        }
    }
    private void OnTriggerEnter( Collider other ) {

        if (other.gameObject.CompareTag("Sword")) {

            /*            Debug.Log(other.gameObject.name);*/

            SwordController sword = other.gameObject.GetComponent<SwordController>();

            if (sword != null) {
                int damage = sword.damage;
                DamageCalculation(damage);
                sword.AttackTarget();
            }


        } else if (other.gameObject.CompareTag("Fireball")) {

            /*Debug.Log("Damage duoc nhan tu: "+ other.gameObject.name);*/

            FireballController fireball = other.gameObject.GetComponent<FireballController>();

            if (fireball != null) {
                int damage = fireball.GetFireBallDamage();
                DamageCalculation(damage);
                fireball.AttackTarget();
            }


        }
    } 

    public void DamageCalculation( int dmg ) {

        monsterHealth -= dmg;

        Debug.Log(monsterHealth);
        if (monsterHealth <= 0) {
            MonsterDie();
        }
    }
    void MonsterDie() {
        Debug.Log("Monster died!");

        monsterReward.SpawnRewardChest();

        Destroy(gameObject);
    }

    void DamageToPlayer() {
        if (!playerController.IsPlayerAlive()) { 
            playerController.PlayerDie();
            return;
        }  // Nhan vat con song ko ?

        int playerHealth = playerController.GetPlayerHealth();


        if (playerHealth <= monsterHealth) {
            playerController.PlayerDie();
            return;
        } else { 

            playerController.SetPlayerHealth(monsterHealth);
            MonsterDie();

        }

        
    }




}
