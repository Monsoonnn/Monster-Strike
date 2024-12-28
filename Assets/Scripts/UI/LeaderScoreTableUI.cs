using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderScoreTableUI : MonoBehaviour {
    [SerializeField] private GameObject rankingItemUI;

    private void Start() {
        // Dummy ranking data
        CreateDummyRanking();

        // Load and parse ranking data from PlayerPrefs
        string json = PlayerPrefs.GetString("RankingData", "[]");
        List<RankingEntry> rankingEntries = JsonUtility.FromJson<RankingList>(json).entries;

        // Display rankings
        int rank = 1;
        foreach (var entry in rankingEntries) {
            Debug.Log($"Player: {entry.playerName}, Score: {entry.score}, Date: {entry.date}");
           
            GameObject rankItem = Instantiate(rankingItemUI, transform);

            TopScoreUI topScoreUI = rankItem.gameObject.GetComponent<TopScoreUI>();

            topScoreUI.Init(rank, entry.score.ToString(), entry.date);

            rank++;

        }
    }

    private void CreateDummyRanking() {
        List<RankingEntry> dummyRanking = new List<RankingEntry> {
            new RankingEntry { playerName = "Player1", score = 100, date = "2024-12-28" },
            new RankingEntry { playerName = "Player2", score = 90, date = "2024-12-27" },
            new RankingEntry { playerName = "Player3", score = 80, date = "2024-12-26" }
        };

        // Sort ranking by score descending
        dummyRanking.Sort(( a, b ) => b.score.CompareTo(a.score));

        RankingList rankingList = new RankingList { entries = dummyRanking };
        string json = JsonUtility.ToJson(rankingList);
        PlayerPrefs.SetString("RankingData", json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    public class RankingEntry {
        public string playerName;
        public int score;
        public string date;
    }

    [System.Serializable]
    public class RankingList {
        public List<RankingEntry> entries;
    }
}