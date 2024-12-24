using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {


    private UIManager manager;
  
    private void Start() {
        Hide();
       
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void Toggle() {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
