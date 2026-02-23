using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public InputActionReference action;
    private int currentView = 0;
    private Vector3 roomPosition = new Vector3(-0.90663f, 0f, 3.06826f);
    private Vector3 outsidePosition = new Vector3(0f, 0f, -45f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (currentView == 0)
            {
               transform.position = roomPosition;
               currentView = 1;
            }
            else if (currentView == 1)
            {
               transform.position = outsidePosition;
               currentView = 0;
            }

        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
