using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealArea : MonoBehaviour
{
    private bool Heal = true;

    private void Update()
    {
        Debug.Log(Heal);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("当たった!");
            Heal = true;
        }
        else
        {
            

        }
    }
    void OnTrggerExit(Collider other)
    {
        Debug.Log("当たってない!");
        Heal = false;
        if (other.gameObject.tag == "Player")
        {
           
        }
    }
}
