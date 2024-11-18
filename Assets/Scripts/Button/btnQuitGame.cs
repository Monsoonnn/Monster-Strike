using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnQuitGame : BaseBtn
{
    protected override void OnClick() {
        Application.Quit();
    }
}
