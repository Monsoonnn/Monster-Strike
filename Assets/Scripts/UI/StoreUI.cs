using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalCoinsUI;
    public static StoreUI Instance { get; private set; }
    void Update()
    {
              
        int totalCoins = PlayerPrefs.GetInt("Coins");

        totalCoinsUI.text = totalCoins.ToString();
    }
    private void Start() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        Hide();
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void Toggle() {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}
