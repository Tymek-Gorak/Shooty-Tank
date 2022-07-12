using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]protected int health;
    protected float attackSpeed = 6.5f;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected GameObject explosion;
    protected int attackDmg;
    protected int cashValue;
    protected SpriteRenderer sprite;
    [SerializeField] protected Sprite[] sprites = new Sprite[2];
    protected int moveSwitch = -1;
    protected SoundManager sound;

    protected void Start()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(health <= 0){
            SpawnManager.enemyAmount--;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Bank.money += cashValue;
            Destroy(gameObject);
        }
    }

    protected virtual void Attack(){
        sound.PlaySound("EShot", 1f);
        GameObject shot = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0f,0f, (-Mathf.Atan2(transform.position.x - -7f, transform.position.y - -3.5f) * Mathf.Rad2Deg) - 90f)));
        shot.GetComponent<Projectile>().damage = attackDmg;
        StartCoroutine("Anim");
    }

    protected void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "goodBullet"){
            sound.PlaySound("Hit", 1f);
            health -= other.GetComponent<Projectile>().damage;
            StartCoroutine("Damaged");
        }
        else if (other.tag == "laser") {
            sound.PlaySound("Hit", 1f);
            health -= other.GetComponentInChildren<LaserProjectile>().damage;
            StartCoroutine("Damaged");
        }
    }

    protected virtual IEnumerator AttackTime(){
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed + Random.Range(-1.5f, 2f));
            Attack();   

        }
    }

    protected IEnumerator Damaged(){
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.35f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0);
    }

    protected IEnumerator Anim(){
        sprite.sprite = sprites[1];
        yield return new WaitForSeconds(0.75f);
        sprite.sprite = sprites[0];
        yield return new WaitForSeconds(0);
    }
}
