using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public static int Waves;
    public int startMoney = 500;
    public int startLives = 20;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Waves = 0;
    }

}
