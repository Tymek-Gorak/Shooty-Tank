using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnSk3 : EnSky
{
    protected new void Start(){
        attackDmg = 150;
        health = 800;
        cashValue = 50;
        base.Start();
    }
}