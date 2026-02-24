using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene
    // Make sure to define the input in the editor (LeftHand/Grip and RightHand/Grip recommended respectively)
    CustomGrab otherHand = null;
    public Hand hand;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    public InputActionReference secondaryAction;
    bool grabbing = false;
    bool doubleRotationMode = true;
    Vector3 previousPosition;
    Quaternion previousRotation;

    private void Start()
    {
        secondaryAction.action.Enable();
        secondaryAction.action.performed += (ctx) =>
        {
            doubleRotationMode = !doubleRotationMode;
        };

        action.action.Enable();

        // Find the other hand
        foreach (CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }

       
    }

    void Update()
    {
       

        grabbing = action.action.IsPressed();
        if (grabbing)
        {

            // Grab nearby object or the object in the other hand
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                Collider[] handColliders = hand.GetComponentsInChildren<Collider>();

                foreach (Collider collider in handColliders)
                {
                    Physics.IgnoreCollision(collider, grabbedObject.GetComponent<Collider>());
                }

                Vector3 deltaPosition = transform.position - previousPosition;
                Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(previousRotation);

                Quaternion doubleDeltaRotation = deltaRotation * deltaRotation;

                Vector3 offset = grabbedObject.position - transform.position;
                Vector3 rotatedOffsetDelta = deltaRotation * offset - offset;
                // Change these to add the delta position and rotation instead
                // Save the position and rotation at the end of Update function, so you can compare previous pos/rot to current here            

                if (doubleRotationMode)
                {
                    rotatedOffsetDelta = doubleDeltaRotation * offset - offset;
                }

                grabbedObject.position += rotatedOffsetDelta + deltaPosition;
                grabbedObject.rotation = deltaRotation * grabbedObject.rotation;
            }
        }
        // If let go of button, release object
        else if (grabbedObject)
        {
            Collider[] handColliders = hand.GetComponentsInChildren<Collider>();

            foreach (Collider collider in handColliders)
            {
                Physics.IgnoreCollision(collider, grabbedObject.GetComponent<Collider>(), false);
            }

            grabbedObject = null;
        }
           

        // Should save the current position and rotation here
        previousPosition = transform.position;
        previousRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make sure to tag grabbable objects with the "grabbable" tag
        // You also need to make sure to have colliders for the grabbable objects and the controllers
        // Make sure to set the controller colliders as triggers or they will get misplaced
        // You also need to add Rigidbody to the controllers for these functions to be triggered
        // Make sure gravity is disabled though, or your controllers will (virtually) fall to the ground

        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Add(t);
            
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Remove(t);
    }
}