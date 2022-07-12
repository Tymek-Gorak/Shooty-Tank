using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanonUpg : MonoBehaviour
{
    private SoundManager sound;
    private TextMeshProUGUI text;
    private string upgrade = "Canon";
    protected static int levelCanon = 0;
    private int[] prices = new int[5] { 100, 300, 500, 1000, 1500};
    private static int currentPrice = 0;

    private void Start() {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        text = transform.GetComponentInParent<TextMeshProUGUI>();
        if(levelCanon < prices.Length)text.text = string.Format("LV: {0}\n{1}$", levelCanon, prices[currentPrice]);
        else text.text = "LV: MAX";
        
    }

    public void Upgrade(){
        
        if(levelCanon < prices.Length - 1 && Bank.money >= prices[currentPrice]){
            Bank.money -= prices[currentPrice];
            currentPrice++;
            levelCanon++;
            sound.PlaySound("Upgrade", 1f);
            Bank.playerDmg = levelCanon;
            text.text = string.Format("LV: {0}\n{1}$", levelCanon, prices[currentPrice]);
        }
        else if (levelCanon == prices.Length - 1 && Bank.money >= prices[currentPrice]){
            Bank.money -= prices[currentPrice];
            levelCanon++;
            sound.PlaySound("Upgrade", 1f);
            Bank.playerDmg = levelCanon;
            text.text = "LV: MAX";
        }
        else{
            sound.PlaySound("UpgradeFail", 1f);
        }
    }

}
