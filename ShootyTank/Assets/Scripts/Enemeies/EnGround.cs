using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnGround : Enemy
{
    [SerializeField] protected Vector3 newPosition;
    protected float speed = 0;
    protected new void Start() {    
        transform.position = new Vector3(12, -4, 0);
        StartCoroutine("move");
        StartCoroutine("AttackTime");
        base.Start();
        StartCoroutine("Animation");
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

    protected IEnumerator move(){
        newPosition = new Vector3(Random.Range(-4f, 7.5f), transform.position.y, transform.position.z);
        speed = Mathf.Abs((transform.position.x - newPosition.x) / 2f);
        while(transform.position != newPosition) {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
            yield return new WaitForSeconds(0);
        }
    }

    protected IEnumerator Animation(){
        while(true){
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0f, 0.05f, 0f) * moveSwitch, 0.01f );
            if(transform.position.y >= -4f){
                moveSwitch = -1;
            }
            else if(transform.position.y <= -4.1f){
                moveSwitch = 1;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
