using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnGr2 : EnGround
{
    protected new void Start(){
        attackDmg = 100;
        health = 350;
        cashValue = 50;
        base.Start();
    }
}