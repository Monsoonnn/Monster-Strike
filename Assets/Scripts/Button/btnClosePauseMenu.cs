using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnClosePauseMenu : BaseBtn
{
    private UIManager uiManager;
    [SerializeField] private PauseMenu pasueMenu;
    protected override void OnClick() {
        uiManager = GameObject.FindAnyObjectByType<UIManager>();

        if (uiManager.isGamePause) { 
            uiManager.GameContinue();
            uiManager.isGamePause = false;
            pasueMenu.Toggle();
        }

    }
}
