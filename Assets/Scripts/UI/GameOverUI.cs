using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinText;

    private ScoreManagerUI scoreManager;

    private void Start() {
        Hide();
        scoreManager = GameObject.FindObjectOfType<ScoreManagerUI>();
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void Toggle() {
        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        } else {
            Show();
        }
    }

    public void Show() {
        if (scoreManager != null) {
            // Hiển thị điểm số và số lượng coin trên màn hình Game Over
            scoreText.text = "SCORE: " + Mathf.FloorToInt(scoreManager.score);
            coinText.text = scoreManager.coins.ToString();

            // Lưu dữ liệu khi game kết thúc
            scoreManager.SaveGame();
        }
        gameObject.SetActive(true);
    }
}
