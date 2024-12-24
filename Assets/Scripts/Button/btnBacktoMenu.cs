using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnBacktoMenu : BaseBtn
{
    UIManager uiManager;
    protected override void OnClick() {
        SceneManager.LoadScene(0);
        uiManager = GameObject.FindAnyObjectByType<UIManager>();
        uiManager.GameContinue();
    }
}
