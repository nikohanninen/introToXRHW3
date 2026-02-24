using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;

    public float openAngle = 90f;
    public float openSpeed = 2f;

    private bool isOpen = false;

    public void Open()
    {
        isOpen = true;
    }

    private void Update()
    {
        if (!isOpen) return;

        // Rotate left door
        leftDoor.localRotation = Quaternion.Lerp(
            leftDoor.localRotation,
            Quaternion.Euler(0, -openAngle, 0),
            Time.deltaTime * openSpeed
        );

        // Rotate right door
        rightDoor.localRotation = Quaternion.Lerp(
            rightDoor.localRotation,
            Quaternion.Euler(0, openAngle, 0),
            Time.deltaTime * openSpeed
        );
    }
}
