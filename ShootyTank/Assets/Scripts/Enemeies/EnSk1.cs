using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnSk1 : EnSky
{
    protected new void Start() {
        attackDmg = 50;
        health = 225;
        cashValue = 50;
        base.Start();
    }
}
