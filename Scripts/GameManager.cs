using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public AudioSource theMusic;

    public GameObject selectedskin;
    public GameObject Player;
    private Sprite playersprite;

    public bool startPlaying;
    public bool endScreen;

    public BeatScroller bS;

    public static GameManager instance;

    public int currentScore;

    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 200;

    public Text scoreText;

    public Text multiText;

    public int currenMultiplier;

    public int multiplierTracker;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missHits;

    public AudioClip aimTraining;
    public AudioClip tryHard;
    public AudioClip trying;
    public AudioClip epic;
    public AudioClip cooking;
    public AudioClip lol;
    public AudioSource soundEffectsSource;

    public GameObject resultScreen;
    public Text percentText, normalText, goodText, perfectText, missText, rankText, finalText;

    public int[] multiplierTresholds;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currenMultiplier = 1;
        totalNotes = FindObjectsOfType<Note>().Length;

        playersprite = selectedskin.GetComponent<SpriteRenderer>().sprite;
        Player.GetComponent<SpriteRenderer>().sprite = playersprite;

        if (soundEffectsSource == null)
        {
            soundEffectsSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                bS.hasStarted = true;

                theMusic.Play();
            }
        }
        else
        {
            if (!theMusic.isPlaying && !resultScreen.activeInHierarchy)
            {
                resultScreen.SetActive(true);
                normalText.text = " " + normalHits;
                goodText.text = goodHits.ToString();
                perfectText.text = perfectHits.ToString();
                missText.text = " " + missHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentText.text = percentHit.ToString("F1") + "%";

                string urRank = "F";

                if (percentHit > 40)
                {
                    urRank = "D";
                    
                    if (percentHit > 55)
                    {
                        urRank = "C";
                        if (percentHit > 70)
                        {
                            urRank = "B";
                            if (percentHit > 85)
                            {
                                urRank = "A";
                                if (percentHit > 90)
                                {
                                    urRank = "S";
                                }
                            }

                        }
                    }
                }

                if (urRank == "F")
                {
                    PlaySound(aimTraining);
                }

                if (urRank == "D")
                {
                    PlaySound(trying);
                }

                if (urRank == "C")
                {
                    PlaySound(lol);
                }

                if (urRank == "B")
                {
                    PlaySound(cooking);
                }

                if (urRank == "A")
                {
                    PlaySound(epic);
                }

                if (urRank == "S")
                {
                    PlaySound(tryHard);
                }

                rankText.text = urRank;
                
                finalText.text = GetCurrentScore().ToString();


            }
        }
    }


    public void NoteHit()
    {
        Debug.Log("Hit on time");
        IncrementMultiplier();

        multiText.text = "Multiplier: x" + currenMultiplier;

        scoreText.text = "Score " + currentScore;
    }

    private void IncrementMultiplier()
    {
        if (currenMultiplier - 1 < multiplierTresholds.Length)
        {
            multiplierTracker++;

            if (multiplierTresholds[currenMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;


                currenMultiplier++;

                IncrementMultiplier(); 
            }
        }

    }

    public void NoteMissed()
    {
        Debug.Log("Note missed");

        currenMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currenMultiplier;
        missHits++;

    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currenMultiplier;
        NoteHit();
        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currenMultiplier;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currenMultiplier;
        NoteHit();
        perfectHits++;
    }

    public void CheckScores()
    {
        // You can add additional recursive score checks if necessary
    }

    public int GetCurrentScore()
    {
      
        int scaledScore = ScaleScore(currentScore, 5);
        return scaledScore;
    }

    
    private int ScaleScore(int score, int max)
    {
       
        if (score < 10 || max <= 0)
        {
            return score;
        }
       
        else
        {
            int scaledScore = score + 10 ;
            return ScaleScore(scaledScore, max - 1);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && soundEffectsSource != null)
        {
            soundEffectsSource.PlayOneShot(clip);
        }
    }
}
