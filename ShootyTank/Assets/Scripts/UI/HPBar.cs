using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Player player;
    private Slider slider;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        slider = transform.GetComponent<Slider>();
        slider.maxValue = (Bank.playerHealth + 1) * 200;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.life;
    }
}
