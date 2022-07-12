using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUpg : MonoBehaviour
{

private SoundManager sound;
    private TextMeshProUGUI text;
    private string upgrade = "Health";
    protected static int levelHP = 0;
    private int[] prices = new int[6] { 150, 200, 400, 600, 1000, 1500};
    private static int currentPrice = 0;

    private void Start() {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        text = transform.GetComponentInParent<TextMeshProUGUI>();
        if(levelHP < prices.Length)text.text = string.Format("LV: {0}\n{1}$", levelHP, prices[currentPrice]);
        else text.text = "LV: MAX";
        
    }

    public void Upgrade(){
        
        if(levelHP < prices.Length - 1 && Bank.money >= prices[currentPrice]){
            Bank.money -= prices[currentPrice];
            currentPrice++;
            levelHP++;
            sound.PlaySound("Upgrade", 1f);
            Bank.playerHealth = levelHP;
            text.text = string.Format("LV: {0}\n{1}$", levelHP, prices[currentPrice]);
        }
        else if (levelHP == prices.Length - 1 && Bank.money >= prices[currentPrice]){
            Bank.money -= prices[currentPrice];
            levelHP++;
            sound.PlaySound("Upgrade", 1f);
            Bank.playerHealth = levelHP;
            text.text = "LV: MAX";
        }
        else{
            sound.PlaySound("UpgradeFail", 1f);
        }
    }
}
