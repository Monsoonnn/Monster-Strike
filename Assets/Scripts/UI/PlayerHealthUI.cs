using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerHealthUI;

    PlayerController player;

    private void Start() {
        
        player = GameObject.FindAnyObjectByType<PlayerController>();    

    }

    private void Update() {
        if (player != null) {
            int health = (int)player.GetPlayerHealth();

            playerHealthUI.text = health.ToString();
        }
    }
}
