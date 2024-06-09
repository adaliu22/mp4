using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Collections;
using UnityEngine.Events; 

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI inputScore;

    [SerializeField] private TMP_InputField inputName;


    public AudioClip highScore;

    public AudioSource soundEffectsSource;

    public UnityEvent<string, int> SubmitScoreEvent;

    public void SubmitScore()
    {

        PlaySound(highScore);
       
        int currentScore = GameManager.instance.GetCurrentScore();
        inputScore.text = currentScore.ToString();

     
        SubmitScoreEvent.Invoke(inputName.text, currentScore);
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null && soundEffectsSource != null)
        {
            soundEffectsSource.PlayOneShot(clip);
        }
    }
}
