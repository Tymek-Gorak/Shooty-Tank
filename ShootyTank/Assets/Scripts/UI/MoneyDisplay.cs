using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    private TextMeshProUGUI text;
    void Start()
    {
        text = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("{0}$", Bank.money);
    }
}
