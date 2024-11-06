using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimator : MonoBehaviour
{
    private const string IS_FLAMING = "IsFlaming";

    [SerializeField] private GameObject dragon;

    private Animator animator;

    private DragonController dragonController;

    private void Awake() {

       animator = GetComponent<Animator>();
       dragonController = dragon.gameObject.GetComponent<DragonController>();

    }

    private void Update() {
        
        animator.SetBool(IS_FLAMING, dragonController.isFlaming);

        

    }


    

}
