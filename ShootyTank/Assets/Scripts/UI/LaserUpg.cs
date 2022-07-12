using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaserUpg : MonoBehaviour
{
    private SoundManager sound;
    private TextMeshProUGUI text;
    private string upgrade = "Laser";
    protected static int levelLaser = 0;
    private int[] prices = new int[5] { 750, 300, 500, 700, 1000};
    private static int currentPrice = 0;

    private void Start() {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        text = transform.GetComponentInParent<TextMeshProUGUI>();
        if(levelLaser < prices.Length)text.text = string.Format("LV: {0}\n{1}$", levelLaser, prices[currentPrice]);
        else text.text = "LV: MAX";
        
    }

    public void Upgrade(){
        
        if(levelLaser < prices.Length - 1 && Bank.money >= prices[currentPrice]){
            Bank.money -= prices[currentPrice];
            currentPrice++;
            sound.PlaySound("Upgrade", 1f);
            levelLaser++;
            Bank.LaserLV = levelLaser;
            text.text = string.Format("LV: {0}\n{1}$", levelLaser, prices[currentPrice]);
        }
        else if (levelLaser == prices.Length - 1 && Bank.money >= prices[currentPrice]){
            Bank.money -= prices[currentPrice];
            levelLaser++;
            sound.PlaySound("Upgrade", 1f);
            Bank.LaserLV = levelLaser;
            text.text = "LV: MAX";
        }
        else{
            sound.PlaySound("UpgradeFail", 1f);
        }
    }
}