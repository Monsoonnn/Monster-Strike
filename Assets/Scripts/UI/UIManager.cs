using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public bool isGamePause = false;
    [SerializeField] PauseMenu pauseMenu;
    public bool isPickingItem = false;
    public bool isGameOver = false;
    private void Update() {

        if (!isPickingItem && !isGameOver) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (!isGamePause) {
                    pauseMenu.Toggle();
                    GamePause();

                } else {
                    pauseMenu.Toggle();
                    GameContinue();

                }
            }
        }

        
    }

    public void GameContinue() {
        if (isGamePause) {
            Time.timeScale = 1.0f;
            isGamePause = false;
        }

    }

    public void GamePause() {
        if (!isGamePause) {
            Time.timeScale = 0f;
            isGamePause = true;
        } 
    }
}
