using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnSk2 : EnSky
{
    protected new void Start(){
        attackDmg = 50;
        health = 425;
        cashValue = 100;
        base.Start();
    }
}
