using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimator : MonoBehaviour
{
    private const string IS_OPEN = "Open";

    [SerializeField] private GameObject chest;

    public Animator animator;

    private RewardDropChest rewardDropChest;

    private void Awake() {

        rewardDropChest = chest.gameObject.GetComponent<RewardDropChest>();

    }

    private void Update() {

        animator.SetBool(IS_OPEN, rewardDropChest.isOpen);

    }
}
