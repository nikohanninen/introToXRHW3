using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    public InputActionReference actionGrip;
    public InputActionReference actionTrigger;
    public Hand hand;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actionGrip.action.Enable();
        actionTrigger.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        hand.SetGrip(actionGrip.action.ReadValue<float>());
        hand.SetTrigger(actionTrigger.action.ReadValue<float>());

        float grip = actionGrip.action.ReadValue<float>();
        float trigger = actionTrigger.action.ReadValue<float>();

        hand.SetGrip(grip);
        hand.SetTrigger(trigger);
    }
}
