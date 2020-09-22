using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropRocks : MonoBehaviour
{
    public List<GameObject> rocks;
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
        if (other.CompareTag("Boar"))
        {
            foreach (GameObject rock in rocks)
            {
                rock.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
