using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardUI : MonoBehaviour
{
    public static LeaderBoardUI Instance { get; private set; }

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
