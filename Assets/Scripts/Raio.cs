using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raio : MonoBehaviour
{
    public GameObject hitRaio;
    public Transform ondeNasce;


   
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
        if (other.tag == ("chao"))
        {
            Instantiate(hitRaio, ondeNasce.position, ondeNasce.rotation);
            Destroy(gameObject);
        }
    }
}
