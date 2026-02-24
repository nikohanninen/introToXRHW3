using UnityEngine;

public class Button : MonoBehaviour
{
    public int buttonID;
    private ButtonManager manager;

    private void Start()
    {
        manager = FindFirstObjectByType<ButtonManager>();
    }

    public void OnPressed()
    {
        manager.RegisterPress(buttonID);
    }
}
