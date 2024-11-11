using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
    // Monster status




    public int monsterHealth;


    PlayerController playerController;

    [SerializeField] private MonsterReward_Script monsterReward;
    [SerializeField] private MonsterDamageUI monsterDamageUI;
    


    void Start() {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        monsterDamageUI.healhUpdate(monsterHealth);
    }

    private void OnCollisionEnter( Collision collision ) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Damage duoc nhan tu: " + collision.gameObject.name);

            DamageToPlayer();

        } 
        
        if (collision.gameObject.CompareTag("Wolf")) {

           

            WolfController wolf = collision.gameObject.GetComponent<WolfController>();

            if (wolf != null && !wolf.hasCollided) // Kiểm tra nếu chưa va chạm
    {
                if (wolf.isFinishedAttack) {
                    Debug.Log("Damage được nhận từ: " + collision.gameObject.name);
                    int wolfDamage = wolf.GetDamage();

                    DamageCalculation(wolfDamage);
                    wolf.isFinishedAttack = false;
                    wolf.hasCollided = true; // Đánh dấu là đã va chạm
                    wolf.BackToPlayer();
                }
            }

        }
    }
    private void OnTriggerEnter( Collider other ) {

        if (other.gameObject.CompareTag("Sword")) {

            Debug.Log(other.gameObject.name);

            SwordController sword = other.gameObject.GetComponent<SwordController>();

            if (sword != null) {
                int damage = sword.damage;
                
                DamageCalculation(damage);
                sword.AttackTarget();
            }


        } else if (other.gameObject.CompareTag("Fireball")) {

            Debug.Log("Damage duoc nhan tu: " + other.gameObject.name);


            FireballController fireball = other.gameObject.GetComponent<FireballController>();

            if (fireball != null) {
                int damage = fireball.GetFireBallDamage();

               

                DamageCalculation(damage);
                fireball.AttackTarget();
            }


        } else if (other.gameObject.CompareTag("Arrow")) {

            Debug.Log("Damage duoc nhan tu: " + other.gameObject.name);

            ArrowController arrow = other.gameObject.GetComponent<ArrowController>();

            if (arrow != null) {

                int arrowDamage = arrow.GetArrowDamage();
                
                DamageCalculation(arrowDamage);
            }

        }

    } 

    public void DamageCalculation( int dmg ) {

        monsterHealth -= dmg;

        monsterDamageUI.DamageUI(dmg);

        monsterDamageUI.healhUpdate(monsterHealth);

        Debug.Log(monsterHealth);
        if (monsterHealth <= 0) {
            MonsterDie();
        }
    }
    void  MonsterDie() {
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
