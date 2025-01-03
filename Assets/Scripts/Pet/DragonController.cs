﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour {
    // Về sau thay thế bằng scriptableObj
    // Cmt bên cạnh là gpt viết hộ

    public int dragonCount;

    private PlayerController player;
    [SerializeField] private Transform fireballSpawnPoint;
    [SerializeField] private GameObject fireball;

    public bool isFlaming { get; set; }
    [SerializeField] private Animator animator;

    FireballController fireballController;

    private void Start() {
        player = GameObject.FindObjectOfType<PlayerController>();

        fireballController = fireball.gameObject.GetComponent<FireballController>();

        fireballController.InitializeFireballProperties();

        float fireballFrequency = 100f / fireballController.GetFireBallFrequency();

        InvokeRepeating("SpawnFireBall", 5f, fireballFrequency);
    }
    void Update() {
        FollowPlayer();
    }


    void FollowPlayer() {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float followSpeed = 5f;
        if (distance >= 1.5f) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }

    }
    public void SpawnFireBall() {

        isFlaming = true;
        int maxCount = fireballController.count;
        if (IsAnimationComplete("Flame_Attack")) {

            Vector3 offset = new Vector3(Random.Range(0.5f, 1f), 0, Random.Range(0.5f, 1f));
            for (int i = 0; i < maxCount; i++) {
                Instantiate(fireball, fireballSpawnPoint.position + offset, Quaternion.identity);
            }

            isFlaming = false;
        }


    }

    public int GetDragonCount() { 
        return dragonCount;
    }

    // Kiểm tra nếu đang trong trạng thái animation mong muốn và animation đã hoàn thành
    private bool IsAnimationComplete( string animationName ) {

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 0.8f;
    }
}
