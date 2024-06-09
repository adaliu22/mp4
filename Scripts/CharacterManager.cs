using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class CharacterManager : MonoBehaviour {
    public SpriteRenderer sr;
    public List<Sprite> characters = new List<Sprite>();
    private int selected = 0;
    public GameObject playerCharacter;
    private string filePath;

    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "selectedCharacter.json");
    }

    public void Next()
    {
        selected++;
        if (selected == characters.Count)
        {
            selected = 0;
        }
        sr.sprite = characters[selected];
    }

    public void Back()
    {
        selected--;
        if (selected < 0)
        {
            selected = characters.Count - 1;
        }
        sr.sprite = characters[selected];
    }

    public void Play()
    {
        SaveCharacter();
        SceneManager.LoadScene("hi");
    }

    private void SaveCharacter()
    {
        if (playerCharacter != null)
        {
            SpriteRenderer playerSr = playerCharacter.GetComponent<SpriteRenderer>();
            playerSr.sprite = sr.sprite;  // Update the playerCharacter sprite to the selected sprite

            CharacterData data = new CharacterData(playerCharacter);
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(filePath, json);
            Debug.Log("Character data saved at: " + filePath);
        }
        else
        {
            Debug.LogError("PlayerCharacter GameObject is not assigned.");
        }
    }
}