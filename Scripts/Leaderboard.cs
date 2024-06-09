using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
public class Leaderboard : MonoBehaviour {
    [SerializeField] private List<TextMeshProUGUI> names;

    [SerializeField] private List<TextMeshProUGUI> scores;


    private string publicKey = "590e1dcdc8c9cc257577d16489b63ef0f034a05607db13ac33d5c4435b871146";
    // private string privateKey = "bc4e00e02994e6a50e6cf70e3a7186d6abc4a895b9ee0825c7a47fa6f16f277b77372942aeed489875de450733094530d16ef5dfdcb97436fc8ebe2722e09 ";

    private void Start()
    {
        GetLeaderboard();
    }
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; ++i)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));



    }

    public void SetLeaderboardEntry(string name, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicKey, name, score, ((msg) => {
            GetLeaderboard();
        }));

        LeaderboardCreator.ResetPlayer();
       
    }

   

}