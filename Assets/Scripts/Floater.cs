using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rb;

    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public Vector3 _localCenterOfMass;


    private void Start()
    {
        rb.centerOfMass = _localCenterOfMass;
    }
    void FixedUpdate()
    {
        if (transform.position.y < 0.1f)
        {
            float displacementMultiplyer = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount; //how much of the object is submerged times displacement amount
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplyer, 0f), ForceMode.Acceleration);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 worldCenterOfMass = transform.TransformPoint(_localCenterOfMass);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.TransformPoint(_localCenterOfMass), 0.1f);
        Gizmos.DrawLine(worldCenterOfMass + Vector3.up, worldCenterOfMass - Vector3.up);
        Gizmos.DrawLine(worldCenterOfMass + Vector3.forward, worldCenterOfMass - Vector3.forward);
        Gizmos.DrawLine(worldCenterOfMass + Vector3.right, worldCenterOfMass - Vector3.right);
    }
}
