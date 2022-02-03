using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject misslePrefab;
    [SerializeField] GameObject explosion;
    [SerializeField] AudioSource missleSoundData;

    private float boundsX = 60.0f;
    private float boundsZ = 30.0f;
    private float spawnPosY = 11.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ConstrainMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, spawnPosY, transform.position.z);
            Instantiate(misslePrefab, spawnPosition, misslePrefab.gameObject.transform.rotation);
            missleSoundData.Play();
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float velocityX = horizontalInput * speed * Time.deltaTime;
        float velocityZ = verticalInput * speed * Time.deltaTime;

        transform.Translate(new Vector3(velocityX, 0, velocityZ));
    }

    private void ConstrainMovement()
    {
        if (transform.position.x < -boundsX)
            transform.position = new Vector3(-boundsX, transform.position.y, transform.position.z);
        else if (transform.position.x > boundsX)
            transform.position = new Vector3(boundsX, transform.position.y, transform.position.z);

        if (transform.position.z < -boundsZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundsZ);
        else if (transform.position.z > boundsZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, boundsZ);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject newExplosion = (GameObject)Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(newExplosion, 10.0f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
