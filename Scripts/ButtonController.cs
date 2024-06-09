using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    private SpriteRenderer sR; // We need to access the sprite renderer to change how the sprite looks

    public Sprite defaultSprite;
    public Sprite pressedSprite;
    public KeyCode keyToPress;

    // Default and enlarged scales
    private Vector3 defaultScale;
    public Vector3 enlargedScale = new Vector3(1.02f, 1.02f, 1.02F); // You can adjust the scale as needed

    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>(); // Get the object that this script is on
        defaultScale = transform.localScale; // Store the default scale
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            sR.sprite = pressedSprite;
            transform.localScale = enlargedScale; // Enlarge the sprite
        }

        if (Input.GetKeyUp(keyToPress))
        {
            sR.sprite = defaultSprite;
            transform.localScale = defaultScale; // Revert to default scale
        }
    }
}