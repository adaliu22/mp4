using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour {
    public List<LeaderboardEntries> leaderboardEntries = new List<LeaderboardEntries>();
    public Transform entryContainer;
    public GameObject entryPrefab;

    void Start()
    {
        // Example: Adding some initial entries
        AddEntry(new LeaderboardEntries("Player1", "Player2" ,1000));
        AddEntry(new LeaderboardEntries("Player2","Player2",900));
        AddEntry(new LeaderboardEntries("Player3", "Player2", 800));
        DisplayLeaderboard(0);
    }

    public void AddEntry(LeaderboardEntries entry)
    {
        leaderboardEntries.Add(entry);
        leaderboardEntries.Sort((x, y) => y.score.CompareTo(x.score)); // Sort in descending order
    }

    public void DisplayLeaderboard(int index)
    {
        if (index >= leaderboardEntries.Count)
            return;

        GameObject newEntry = Instantiate(entryPrefab, entryContainer);
        Text[] texts = newEntry.GetComponentsInChildren<Text>();
        texts[0].text = (index + 1).ToString(); // Rank
        texts[1].text = leaderboardEntries[index].playerName1; // Player Name
        texts[2].text = leaderboardEntries[index].playerName2; // Player Name
        texts[3].text = leaderboardEntries[index].score.ToString(); // Score

        DisplayLeaderboard(index + 1); // Recursive call to display the next entry
    }
}