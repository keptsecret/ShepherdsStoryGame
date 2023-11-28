using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpLevel1 : MonoBehaviour
{
    public AudioSource tickSource;
    public bool hasBeenActivated;
    [SerializeField] private ParticleSystem prefab;
    // Start is called before the first frame update
    void Start()
    {
        tickSource = GetComponent<AudioSource>();
        hasBeenActivated = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            prefab.Play();
            tickSource.Play();
            hasBeenActivated = true;
        }

    }
}
