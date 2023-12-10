using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int coinsValue = 0;
    Text coins;

    private void Start()
    {
        coins = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "coins : " + coinsValue;
    }
}
