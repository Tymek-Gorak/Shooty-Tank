using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TransportShip : EnSky
{
    protected new void Start()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sprite = transform.GetComponent<SpriteRenderer>();
        attackDmg = 0;
        health = 4000;
        cashValue = 1000;
        transform.position = new Vector3(11, 4, 0);
        StartCoroutine("move");
    }

    protected override void Update()
    {
        if(health <= 0){
            SpawnManager.enemyAmount--;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Bank.money += cashValue;
            GameObject g = Instantiate(explosion, transform.position, Quaternion.identity);
            g.transform.localScale = new Vector3(3.386107f, 3.386107f, 3.386107f);
            g.GetComponent<Explosion>().explosions = 4;
            Destroy(gameObject);
        }
    }
}
