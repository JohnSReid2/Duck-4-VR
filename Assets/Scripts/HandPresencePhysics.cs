using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{

    public Transform target;
    private Rigidbody rb;
    private Collider[] handColliders;

    private bool grabbing;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 200;

        handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandColliderDelay(float delay)
    {
        Invoke("EnableHandCollider", delay);
    }    
    public void EnableHandCollider()
    {
        if (grabbing == false)
        {
            foreach (var item in handColliders)
            {
                item.enabled = true;
            }
        }
        
    }

    public void DisableHandCollider()
    {
        foreach (var item in handColliders)
        {
            item.enabled = false;
        }
    }

    public void GrabRelease()
    {
        grabbing = false;
    }

    public void GrabEngage()
    {
        grabbing = true;
    }

    
    void FixedUpdate()
    {

        //position
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        //rotation 
        Quaternion rotationDfference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDfference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
        
    }
}
