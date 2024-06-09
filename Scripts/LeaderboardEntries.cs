using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LeaderboardEntries
{
    public string playerName1, playerName2;
    public int score;

    public LeaderboardEntries(string playerName1, string playerName2, int score)
    {
        this.playerName1 = playerName1;
        this.playerName2 = playerName2;
        this.score = score;
    }
}
