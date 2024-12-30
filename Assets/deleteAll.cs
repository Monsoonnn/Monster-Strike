using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAll : MonoBehaviour {

   
    private int zeroPressCount = 0; // Đếm số lần nhấn nút 0
    private float resetTime = 1.0f; // Thời gian để reset lại đếm (nếu không nhấn liên tiếp)
    private float lastPressTime; // Thời gian lần cuối nút 0 được nhấn

    void Start() {
        
        // Khởi tạo số coin nếu chưa tồn tại
        if (!PlayerPrefs.HasKey("Coins")) {
            PlayerPrefs.SetInt("Coins", 0);
        }

    }

    void Update() {
        // Kiểm tra nếu người dùng nhấn phím "0"
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            float currentTime = Time.time;

            // Nếu thời gian giữa các lần nhấn quá lâu, reset lại đếm
            if (currentTime - lastPressTime > resetTime) {
                zeroPressCount = 0;
            }

            // Cập nhật thời gian và số lần nhấn
            lastPressTime = currentTime;
            zeroPressCount++;

            // Nếu nhấn đủ 3 lần liên tiếp, thêm 1000 coins
            if (zeroPressCount == 3) {
                AddCoins(1000);
                zeroPressCount = 0; // Reset lại đếm
            }
        }
    }

    void AddCoins( int amount ) {
        int currentCoins = PlayerPrefs.GetInt("Coins");
        currentCoins += amount;
        PlayerPrefs.SetInt("Coins", currentCoins);
        
    }

   

}

