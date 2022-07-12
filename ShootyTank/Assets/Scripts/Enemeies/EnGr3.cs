using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnGr3 : EnGround
{
    protected new void Start(){
        attackDmg = 150;
        health = 751;
        cashValue = 50;
        base.Start();
    }
}