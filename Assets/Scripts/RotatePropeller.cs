using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeller : MonoBehaviour
{
    [SerializeField] Vector3 axis;
    private float rotationSpeed = 2000.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis, rotationSpeed * Time.deltaTime);
    }
}
