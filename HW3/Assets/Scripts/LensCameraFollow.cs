using UnityEngine;

public class LensCameraFollow : MonoBehaviour
{
    public Transform vrCamera;
    public Transform lens;

    void LateUpdate()
    {
        //transform.position = lens.position;
        ////transform.rotation = vrCamera.rotation;
        //transform.LookAt(lens.position - vrCamera.position);

        transform.position = lens.position;

        // Vector from eye to lens
        Vector3 direction = lens.position - vrCamera.position;

        // Convert direction to a world-space look-at point
        Vector3 lookAtPoint = lens.position + direction;

        // Look in that direction
        transform.LookAt(lookAtPoint, lens.up);
    }
}