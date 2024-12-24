using TMPro;
using UnityEngine;

public class ScoreManagerUI : MonoBehaviour {
    public float score = 0f;          // Điểm chạy được
    public int coins = 0;            // Số lượng coin thu thập
    public int multiplier = 1;       // Nhân điểm (mặc định = 1)

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinsText;

    private float timer = 0f;        // Bộ đếm thời gian
    private const float interval = 0.2f; // Khoảng thời gian mỗi lần tăng điểm (5 giây)
    private const float pointsPerInterval = 0.5f; // Điểm tăng mỗi 5 giây
    private int lastCoinThreshold = 0; // Số điểm đã được chuyển đổi thành coin

    private void Start() {
        UpdateUI();
    }
    void Update() {
        // Tăng bộ đếm thời gian
        timer += Time.deltaTime;

        // Nếu đủ 5 giây, tăng điểm
        if (timer >= interval) {
            timer -= interval; // Reset bộ đếm thời gian
            score += pointsPerInterval * multiplier; // Tăng điểm

            // Cập nhật coin nếu đạt ngưỡng
            while (Mathf.FloorToInt(score) / 10 > lastCoinThreshold) {
                lastCoinThreshold++; // Tăng ngưỡng điểm đã đạt
                coins++;             // Cộng thêm 1 coin
            }

            UpdateUI(); // Cập nhật giao diện
        }
    }

    public void CollectCoin( int coinValue = 1 ) {
        coins += coinValue;
        UpdateUI();
    }

    public void SetMultiplier( int newMultiplier ) {
        multiplier = newMultiplier;
    }

    private void UpdateUI() {
        // Hiển thị điểm số và số coin
        if (scoreText != null)
            scoreText.text = "Score: " + Mathf.FloorToInt(score);

        if (coinsText != null)
            coinsText.text = coins.ToString();
    }

    public void SaveGame() {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Score", Mathf.FloorToInt(score));
        PlayerPrefs.Save();
    }

    public void LoadGame() {
        coins = PlayerPrefs.GetInt("Coins", 0);
        score = PlayerPrefs.GetInt("Score", 0);
        UpdateUI();
    }

    public void ResetGame() {
        score = 0f;
        coins = 0;
        lastCoinThreshold = 0;
        timer = 0f;
        UpdateUI();
    }
}
