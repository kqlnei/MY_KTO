using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealArea : MonoBehaviour
{
    [HideInInspector] public bool Heal = false;

    private void Update()
    {
        Debug.Log(Heal);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("��������!");
            Heal = true;
        }
        else
        {
            

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("�������ĂȂ�!");
            Heal = false;
        }
    }
}
