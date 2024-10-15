using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCollider : MonoBehaviour

    
{
    // Start is called before the first frame update
    public GameObject particles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(particles, transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Duck")
        {
            Instantiate(particles, transform);
            Destroy(other.gameObject);
            
        }
    }
}
