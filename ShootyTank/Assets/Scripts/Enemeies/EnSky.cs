using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnSky : Enemy
{
    [SerializeField] private Vector3 newPosition;
    private float speed = 0;
    protected new void Start()
    {
        transform.position = new Vector3(12, 4, 0);
        StartCoroutine("move");
        StartCoroutine("AttackTime");
        base.Start();
    }

    protected override IEnumerator AttackTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            
            Attack();   
            StartCoroutine("move");         
            yield return new WaitForSeconds(0f);
        }
    }

    private IEnumerator move(){
        newPosition = new Vector3(Random.Range(-2f, 7.5f), Random.Range(0f, 3.5f), transform.position.z);
        speed = Mathf.Abs((transform.position.x - newPosition.x) / 2f);
        while(transform.position != newPosition) {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
            yield return new WaitForSeconds(0);
        }
    }
}
