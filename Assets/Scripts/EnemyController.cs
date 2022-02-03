using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;

    private float bottomBorderZ = -40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posZ = transform.position.z - speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, posZ);

        if (transform.position.z < bottomBorderZ)
        {
            Destroy(gameObject);
        }
    }
}
