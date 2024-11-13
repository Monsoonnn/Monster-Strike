using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceDamageUI : MonoBehaviour {
    public float detectionRadius;
    
    public GameObject reduceDamageUI; 

    private PlayerController playerController; 

    void Start() {

        playerController = GameObject.FindObjectOfType<PlayerController>();

    }

    void Update() {
        if (playerController != null) {
            DetectPlayerInRange();
        }
    }

    void DetectPlayerInRange() {
        // Tìm tất cả các đối tượng trong phạm vi detectionRadius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);

        // Duyệt qua tất cả các collider tìm được
        foreach (var hitCollider in hitColliders) {
            // Kiểm tra tag "Player"
            if (hitCollider.CompareTag("Player")) {
                PlayerController targetPlayerController = hitCollider.GetComponent<PlayerController>();
                if (targetPlayerController != null && targetPlayerController.HasImpactBelt()) {
                    // Kích hoạt UI nếu thỏa mãn điều kiện
                    reduceDamageUI.SetActive(true);
                    return; // Dừng tìm kiếm khi tìm thấy đối tượng hợp lệ
                }

            }
        }

        // Nếu không có Player trong phạm vi hoặc không thỏa mãn điều kiện, ẩn UI
        reduceDamageUI.SetActive(false);
    }
}
