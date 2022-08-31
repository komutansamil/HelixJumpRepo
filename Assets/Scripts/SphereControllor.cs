using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControllor : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Manager manager;
    [SerializeField] private GameObject _splashprite;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    float forceValue = 250f;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * forceValue);
    }

    void OnCollisionEnter(Collision col)
    {
        if (!manager.IsGameOver)
        {
            Jump();
        }

        if (col.gameObject.tag == "SafeArea")
        {
            manager.EarnedPoint += 100;
            manager.EarnedPoint_Txt.text = manager.EarnedPoint.ToString();
        }
        if (col.gameObject.tag == "UnsafeArea")
        {
            manager.IsGameOver = true;
        }
        if (col.gameObject.tag == "FinishArea")
        {
            manager.IsGameOver = true;

            manager.TotalPoint_Txt.text = manager.TotalPoint.ToString();
        }

        _audioSource.PlayOneShot(_audioClip);

        Vector3 pos = new Vector3(col.GetContact(0).point.x, col.GetContact(0).point.y + 0.1f, col.GetContact(0).point.z);
        var sprite = Instantiate(_splashprite, pos, Quaternion.identity);
        sprite.transform.SetParent(col.gameObject.transform);
        Destroy(sprite, 5f);
    }
}
