using UnityEngine;
using System;

[Serializable]
public class CharacterData {
    public string name;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public string spriteName;

    public CharacterData(GameObject obj)
    {
        name = obj.name;
        position = new Vector3(-0.28f, 2.77f, 6.249684f);
        rotation = obj.transform.rotation;


        scale = new Vector3(0.58f,0.58f,0.58f);
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null && sr.sprite != null)
        {
            spriteName = sr.sprite.name; 
        }
    }

    public void ApplyTo(GameObject obj)
    {
        obj.name = name;
        obj.transform.position = position;

        obj.transform.rotation = rotation;
        obj.transform.localScale = scale;
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null && !string.IsNullOrEmpty(spriteName))


        {
            sr.sprite = Resources.Load<Sprite>(spriteName);
        }
    }
}