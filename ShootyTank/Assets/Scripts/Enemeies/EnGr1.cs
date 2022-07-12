using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnGr1 : EnGround
{
    protected new void Start(){
        attackDmg = 50;
        health = 151;
        cashValue = 50;
        base.Start();
    }
}
