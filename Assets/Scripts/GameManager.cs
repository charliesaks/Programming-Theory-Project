using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Play Explosion Sound
    public void PlayExplosionSound()
    {
        explosionSound.Play();
    }
}
