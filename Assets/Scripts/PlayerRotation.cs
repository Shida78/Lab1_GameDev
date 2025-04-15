using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform player;
    public Transform visor;

    [Range(50, 300)]
    public float xSens;
    [Range(50, 300)]
    public float ySens;

    Quaternion center;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
