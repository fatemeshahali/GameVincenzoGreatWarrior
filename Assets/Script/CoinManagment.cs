using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class CoinManagment : MonoBehaviour
{
    public int gold;
    public Text money;

    void Start()
    {
        gold = PlayerPrefs.GetInt("Money" , 0);
    }

    void Update()
    {
        money.text = PlayerPrefs.GetInt("Money" , 0).ToString();
    }

    public void Addmoney() {
        gold++;
        PlayerPrefs.SetInt("Money" , gold);
    }
}
