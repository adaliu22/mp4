using UnityEngine;

public class RotateCharacter : MonoBehaviour {
    public float rotationSpeed = 100f;
    private bool isRotating = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRotating = !isRotating;
        }

        if (isRotating)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}