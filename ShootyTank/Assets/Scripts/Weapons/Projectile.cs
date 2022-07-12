using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float shotSpeed = 10f;

    private void Start()
    {
        transform.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(shotSpeed, 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<SpriteRenderer>().isVisible){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && transform.tag == "badBullet" || transform.tag == "goodBullet" && other.tag == "enemy" || other.tag == "floor")
        {
        Destroy(gameObject);
        }
    }
}
