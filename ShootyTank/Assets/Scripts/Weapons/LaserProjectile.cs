using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public int damage;
    void Start()
    {
        StartCoroutine("Dissapear");
    }

    private IEnumerator Dissapear(){
        yield return new WaitForSeconds(0.1f);
        Destroy(transform.GetComponent<BoxCollider2D>());
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
