using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAll : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Coins", 1000);
        
    }

}