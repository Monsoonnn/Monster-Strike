using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderScoreTableUI : MonoBehaviour {
    [SerializeField] private GameObject rankingItemUI;

    private void Start() {
        // Load and parse ranking data from PlayerPrefs
        string json = PlayerPrefs.GetString("RankingData");
        List<RankingEntry> rankingEntries;

        // Check if JSON is empty or invalid
        if (string.IsNullOrEmpty(json) || json == "[]") {
            rankingEntries = new List<RankingEntry>();
        } else {
            try {
                rankingEntries = JsonUtility.FromJson<RankingList>(json).entries;
            }
            catch {
                rankingEntries = new List<RankingEntry>();
            }
        }

        // Display rankings
        int rank = 1;
        foreach (var entry in rankingEntries) {
           

            GameObject rankItem = Instantiate(rankingItemUI, transform);

            TopScoreUI topScoreUI = rankItem.gameObject.GetComponent<TopScoreUI>();

            topScoreUI.Init(rank, entry.score.ToString(), entry.date);

            rank++;
        }
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
