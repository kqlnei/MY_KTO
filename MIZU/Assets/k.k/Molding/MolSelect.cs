using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolSelect : MonoBehaviour
{
    private string selTag = "sel";

    public Material materialon;
    public Material materialoff;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(selTag))
        {

            Debug.Log(collision.gameObject.name);
            Debug.Log("1");

            collision.gameObject.GetComponent<Renderer>().material = materialon;
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(selTag))
        {
            collision.gameObject.GetComponent<Renderer>().material = materialoff;
        }
    }
}
    
