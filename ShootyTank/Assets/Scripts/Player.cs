using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] public int life;
    static SpriteRenderer sprite;
    private int moveSwitch = -1;
    private SoundManager sound;
    
    void Start()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sprite = transform.GetComponent<SpriteRenderer>();
        life = (Bank.playerHealth + 1) * 200;
        StartCoroutine("Animation");
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0){
            Death();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "badBullet"){
            life -= other.GetComponent<Projectile>().damage;
            sound.PlaySound("Hit", 1f);
            StartCoroutine("Damaged");
        }
    }

    private void Death(){
        GameObject g = Instantiate(explosion, transform.position, Quaternion.identity);
        g.transform.localScale = new Vector3(3.386107f, 3.386107f, 3.386107f);
        g.GetComponent<Explosion>().explosions = 5;
    }

    private IEnumerator Damaged(){
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.75f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0);
    }

    private IEnumerator Animation(){
        while(true){
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0f, 0.05f, 0f) * moveSwitch, 0.01f );
            if(transform.position.y >= -3.3f){
                moveSwitch = -1;
            }
            else if(transform.position.y <= -3.4f){
                moveSwitch = 1;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
