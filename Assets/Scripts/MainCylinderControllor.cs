using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCylinderControllor : MonoBehaviour
{
    #region Values
    [SerializeField] private Manager manager;
    float _rotateSpeed = 1500f;
    #endregion

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!manager.IsGameOver && manager.IsStartTheGame)
        {
            Controllor();
        }
    }

    void Controllor()
    {
        float MouseX = -Input.GetAxis("Mouse X");
        if(Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed * MouseX);
        }
    }
}
