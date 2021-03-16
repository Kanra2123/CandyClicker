using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text text;
    public float money = 0;
    string tmp;
    public long realMoney = 0;

    public string convert(long rel)
    {
        double mon = rel;
        int j = 0;
        string letter = null;
        string pomoc = null;

        while (mon>=1000)
        {
            j++;
            mon /= 1000;
        }



        switch (j)
        {
            case 1:
                letter = "k";
                break;

            case 2:
                letter = "m";
                break;

            case 3:
                letter = "b";
                break;

            case 4:
                letter = "t";
                break;

            case 5:
                letter = "qa";
                break;

            case 6:
                letter = "qi";
                break;

            default:
                letter = "";
                break;
        }

        pomoc = mon.ToString("0.00") + letter;
        return pomoc;
    }

    public void AddMoney(long value)
    {
        realMoney += value;
        money += value;

        tmp = convert(realMoney);

        text.text = tmp;
    }

    private void Update()
    {
        if (realMoney >= 1000000000000000)
        {
            realMoney = 1000000000000000;
            tmp = convert(realMoney);
            text.text = tmp;
            FindObjectOfType<WinMenager>().EndGame();
        }
    }
}
