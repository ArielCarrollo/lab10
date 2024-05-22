using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proyectile1 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;


    private void Start() {
        myRB = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        float angle = Mathf.Atan2(myRB.velocity.y, myRB.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if(this.transform.position.y <= -5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}

