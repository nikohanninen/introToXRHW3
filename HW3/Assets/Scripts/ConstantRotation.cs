using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float degreestPerSecond = 10.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, degreestPerSecond * Time.deltaTime, 0);
    }
}
