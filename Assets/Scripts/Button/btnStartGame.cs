using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnStartGame : BaseBtn
{
   
    protected override void OnClick() {
        SceneManager.LoadScene(1);
        
        // Hàm restart 
    }
}
