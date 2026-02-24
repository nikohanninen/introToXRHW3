using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public int[] correctOrder; 
    private int currentIndex = 0;
    public Door door;

    public void RegisterPress(int buttonID)
    {
        if (buttonID == correctOrder[currentIndex])
        {
            currentIndex++;

            if (currentIndex >= correctOrder.Length)
            {
                Unlock();
            }
        }
        else
        {
            currentIndex = 0;
        }
    }

    private void Unlock()
    {
        door.Open();
    }
}
