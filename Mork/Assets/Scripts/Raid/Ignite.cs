using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ignite : MonoBehaviour
{
    public ParticleSystem fire;
    public float fireScale;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torch"))
        {
            ParticleSystem newFire = Instantiate(fire, transform.position, transform.rotation);
            newFire.transform.localScale *= fireScale;
            newFire.Play();
        }
    }
}
