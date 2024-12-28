using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimator : MonoBehaviour {
    private const string Is_Near_Monster = "IsNearMonster";

    [SerializeField] private GameObject wolf;

    private Animator animator;

    private WolfController wolfController;
    [SerializeField] private GameObject hitbox;



    private void Awake() {

        animator = GetComponent<Animator>();
        wolfController = wolf.gameObject.GetComponent<WolfController>();

    }

    private void Update() {

        animator.SetBool(Is_Near_Monster, wolfController.isNearMonster);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("attack1")) {
            if (stateInfo.normalizedTime >= 1.0f) {

                SwapActiveHitBox();
                wolfController.isFinishedAttack = true;
             
            }
            SwapActiveHitBox();
        }

    }

    public void AttackAnimation() {
        
    }

    private void SwapActiveHitBox() {
        hitbox.SetActive(!hitbox.activeSelf);
    }

}
