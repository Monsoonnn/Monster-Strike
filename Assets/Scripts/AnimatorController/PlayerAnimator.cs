using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_ACHERY = "IsAchery";

    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject arrow;

    private Animator animator;


    private ArrowController arrowController;
    

    private void Awake() {
        
        animator = GetComponent<Animator>();
        arrowController = arrow.gameObject.GetComponent<ArrowController>();

    }

    private void Update() {
        animator.SetBool(IS_ACHERY, true);
        animator.speed =  arrowController.GetArrowFrequency() / 58f ; // config tốc độ animation
       
    }

}
