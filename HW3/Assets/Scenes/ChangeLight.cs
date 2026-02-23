using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeLight : MonoBehaviour
{
    public InputActionReference action;
    public Light light;
    private Color red = new Color(1f, 0f, 0f);
    private Color white = new Color(1f, 1f, 1f);
    private int lightState = 0;
    void Start()
    {
        light = GetComponent<Light>();

        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if(lightState == 0)
            {
                lightState = 1;
                light.color = white;
            }else if (lightState == 1)
            {
                lightState = 0;
                light.color = red;
            }

        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
