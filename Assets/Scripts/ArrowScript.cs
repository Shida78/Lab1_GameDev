using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LineRenderer))]
public class ArrowScript : MonoBehaviour
{
    LineRenderer lr;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()   //выполняется опсле Update
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + rb.linearVelocity);
    }
}
