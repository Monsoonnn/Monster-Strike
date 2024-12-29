using TMPro;
using UnityEngine;
using System.Collections.Generic;

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
            scoreText.text = "SCORE: " + Mathf.FloorToInt(scoreManager.score).ToString();
            coinText.text = scoreManager.newCoins.ToString();

            // Lưu dữ liệu khi game kết thúc
            UpdateLeaderboard(Mathf.FloorToInt(scoreManager.score));
            scoreManager.SaveGame();
        }
        gameObject.SetActive(true);
    }

    private void UpdateLeaderboard( int currentScore ) {
        // Load existing leaderboard data
        string json = PlayerPrefs.GetString("RankingData", "[]");
        List<LeaderScoreTableUI.RankingEntry> rankingEntries;

        // Check if JSON is empty or invalid
        if (string.IsNullOrEmpty(json) || json == "[]") {
            rankingEntries = new List<LeaderScoreTableUI.RankingEntry>();
        } else {
            try {
                rankingEntries = JsonUtility.FromJson<LeaderScoreTableUI.RankingList>(json).entries;
            }
            catch {
                rankingEntries = new List<LeaderScoreTableUI.RankingEntry>();
            }
        }

        // Add new entry
        rankingEntries.Add(new LeaderScoreTableUI.RankingEntry {
            playerName = "CurrentPlayer", // Replace with actual player name if available
            score = currentScore,
            date = System.DateTime.Now.ToString("yyyy-MM-dd")
        });

        // Sort by score descending and keep only the top 5 entries
        rankingEntries.Sort(( a, b ) => b.score.CompareTo(a.score));
        if (rankingEntries.Count > 5) {
            rankingEntries = rankingEntries.GetRange(0, 5);
        }

        // Save updated leaderboard
        LeaderScoreTableUI.RankingList rankingList = new LeaderScoreTableUI.RankingList { entries = rankingEntries };
        json = JsonUtility.ToJson(rankingList);
        PlayerPrefs.SetString("RankingData", json);

        Debug.Log(PlayerPrefs.GetString("RankingData"));

        PlayerPrefs.Save();
    }
}
