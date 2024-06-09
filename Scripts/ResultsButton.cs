using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsButton : MonoBehaviour
{
    public void EndGame()
    {

        SceneManager.LoadScene("EndScreen");
    }
}
