using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleController : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    private float speed = 100f;
    private float topBorderZ = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posZ = transform.position.z + speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, posZ);

        if (transform.position.z > topBorderZ)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject newExplosion = (GameObject) Instantiate(explosion, collision.gameObject.transform.position, explosion.transform.rotation);
            GameManager.instance.PlayExplosionSound();
            Destroy(newExplosion, 5.0f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
