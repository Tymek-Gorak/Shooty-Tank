using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    private void Start(){
        damages = new int[6]{0, 100, 100, 80, 60, 50};
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        cooldowns = new float[6]{0f, 2f, 1.5f, 1f, 0.7f, 0.4f};
        cooldown = cooldowns[Bank.LaserLV];
        damage = damages[Bank.LaserLV];
        StartCoroutine("Shoot");
        if(Bank.LaserLV <= 0){
            gameObject.SetActive(false);
        }
    }
}
