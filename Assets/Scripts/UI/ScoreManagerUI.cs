using TMPro;
using UnityEngine;

public class ScoreManagerUI : MonoBehaviour {
    public float score = 0f;          // Điểm chạy được
    public int coins = 0;            // Tổng số coin toàn game
    public int newCoins = 0;         // Số lượng coin mới trong lần chơi hiện tại
    public int multiplier = 1;       // Nhân điểm (mặc định = 1)

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI newCoinsText; // UI hiển thị số coin mới kiếm được

    private float timer = 0f;        // Bộ đếm thời gian
    private const float interval = 0.2f; // Khoảng thời gian mỗi lần tăng điểm
    private const float pointsPerInterval = 0.5f; // Điểm tăng mỗi lần
    private int lastCoinThreshold = 0; // Số điểm đã được chuyển đổi thành coin

    private void Start() {
        /*Reset();*/
        LoadGame();
        ResetNewCoins(); // Đặt lại số coin mới khi bắt đầu game
        UpdateUI();
    }

    void Update() {
        // Tăng bộ đếm thời gian
        timer += Time.deltaTime;

        // Nếu đủ thời gian, tăng điểm
        if (timer >= interval) {
            timer -= interval; // Reset bộ đếm thời gian
            score += pointsPerInterval * multiplier; // Tăng điểm

            // Cập nhật coin nếu đạt ngưỡng
            while (Mathf.FloorToInt(score) / 30 > lastCoinThreshold) {
                lastCoinThreshold++; // Tăng ngưỡng điểm đã đạt
              
                newCoins++;          // Cộng coin vào coin mới
            }

            UpdateUI(); // Cập nhật giao diện
        }
    }

    public void SetMultiplier( int newMultiplier ) {
        multiplier = newMultiplier;
    }

    private void UpdateUI() {
        // Hiển thị điểm số
        if (scoreText != null)
            scoreText.text = "SCORE: " + Mathf.FloorToInt(score);

        // Hiển thị tổng số coin
        if (coinsText != null) {
            int textCoin = coins + newCoins;
            coinsText.text = textCoin.ToString();
        }
            

        
    }

    public void SaveGame() {
        coins += newCoins; 
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Score", Mathf.FloorToInt(score));
        PlayerPrefs.Save();
        ResetNewCoins(); // Đặt lại coin mới sau khi lưu
    }

    public void LoadGame() {
        coins = PlayerPrefs.GetInt("Coins");
        UpdateUI();
    }

    public void ResetGame() {
        score = 0f;
        ResetNewCoins(); // Đặt lại coin mới khi reset game
        lastCoinThreshold = 0;
        timer = 0f;
        UpdateUI();
    }

    private void ResetNewCoins() {
        newCoins = 0;
    }


    private void Reset() {
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
    }
}
