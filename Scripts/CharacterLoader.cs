using UnityEngine;
using System.IO;

public class CharacterLoader : MonoBehaviour {
    public GameObject playerCharacterPrefab;
    private string filePath;

    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "selectedCharacter.json");
        LoadCharacter();
    }

    private void LoadCharacter()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            CharacterData data = JsonUtility.FromJson<CharacterData>(json);

            GameObject playerCharacter = Instantiate(playerCharacterPrefab);
            data.ApplyTo(playerCharacter);

            // Add the SpinCharacter script to the playerCharacter
            playerCharacter.AddComponent<RotateCharacter>();

            Debug.Log("Character data loaded from: " + filePath);
        }
        else
        {
            Debug.LogError("Save file not found at: " + filePath);
        }
    }
}