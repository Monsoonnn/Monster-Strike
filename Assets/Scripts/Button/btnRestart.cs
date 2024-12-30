using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnRestart : BaseBtn
{
    private UIManager UIManager;

    protected override void OnClick() {

        UIManager = GameObject.FindAnyObjectByType<UIManager>();

        

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (UIManager.isGamePause) {
            
            UIManager.GameContinue();

            LoaderItem.Instance.LoadItem();
        }
    }
}
