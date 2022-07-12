using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPText : MonoBehaviour
{
    private Player player;
    private TextMeshProUGUI text;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        text = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("HP: {0}", player.life);
    }
}
