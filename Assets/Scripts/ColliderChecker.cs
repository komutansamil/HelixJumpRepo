using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderChecker : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Ball")
        {
            this.gameObject.transform.parent.gameObject.SetActive(false);
            Debug.Log(this.gameObject.transform.parent.gameObject.name);
        }
    }
}
