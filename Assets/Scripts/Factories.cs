using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factories : MonoBehaviour
{
    public Text lvlText;
    public Text costText;
    public Text MoneyPerTimeText;
    float theTime;
    public float speed = 1f;
    public long realMoneyPerTime = 0;
    public long realCost = 0;
    string Cost = null;
    public long RealLvl = 0;
    public float CostMultipler = 30f;
    public float MoneyMultipler = 5f;
    public Slider slider;
    public float time;
    public float FasterBy = 1;
    float timeMultipler = 1;

    
    private void Start()
    {
        Cost =  FindObjectOfType<Money>().convert(realCost);

        lvlText.text = RealLvl.ToString("0.00") ;
        costText.text = Cost;
        MoneyPerTimeText.text = "0";
    }

    void Update()
    {
        if (RealLvl > 0.9f)
        {
            timeMultipler = Mathf.Floor(RealLvl / FasterBy) +1;
          
            theTime += Time.deltaTime * speed * timeMultipler;
            slider.value = theTime;
            if (theTime > time)
            {
                theTime = 0;
                FindObjectOfType<Money>().AddMoney(realMoneyPerTime);
            }
        }
    }

    public void lvlUp ()
    {
        if (realCost <= FindObjectOfType<Money>().realMoney)
        {
            RealLvl++;
            FindObjectOfType<AudioMenager>().Play("LvlUp");

            FindObjectOfType<Money>().AddMoney(-realCost);
            realCost += (long)Mathf.Floor((realCost / 10) + CostMultipler*RealLvl);
            realMoneyPerTime += (long)Mathf.Floor((realMoneyPerTime / 10) + RealLvl*MoneyMultipler);

            lvlText.text = FindObjectOfType<Money>().convert(RealLvl);
            costText.text = FindObjectOfType<Money>().convert(realCost);
            MoneyPerTimeText.text = FindObjectOfType<Money>().convert(realMoneyPerTime);
        }
    }
}
