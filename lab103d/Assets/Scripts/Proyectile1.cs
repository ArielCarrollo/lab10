using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile1 : MonoBehaviour
{
    [SerializeField] private Rigidbody myRB;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float angle = Mathf.Atan2(myRB.velocity.y, myRB.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.LookRotation(myRB.velocity);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}

