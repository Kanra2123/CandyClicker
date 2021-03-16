using UnityEngine;
using UnityEngine.UI;

public class MainButtonMenager : MonoBehaviour
{
    public long MoneyPerClick = 0;
    public long realLvl = 1;
    string lvl;
    public long realCost = 5;
    string cost;
    public float CostMultipler = 5;
    public Text lvlText;
    public Text costText;

    private void Start()
    {
        lvl = realLvl.ToString("0.00");
        cost = realCost.ToString("0.00");
        
        lvlText.text = lvl;
        costText.text = cost;
    }

    public void OnClick()
    {
        FindObjectOfType<Money>().AddMoney(MoneyPerClick);
        FindObjectOfType<AudioMenager>().Play("CandyClick");
    }

    public void LvlUp ()
    {
        if (realCost <= FindObjectOfType<Money>().realMoney)
        {
            realLvl++;

            FindObjectOfType<Money>().AddMoney(-realCost);
            realCost += (long)(realCost + CostMultipler + realLvl);
            MoneyPerClick += 1;

            lvl = FindObjectOfType<Money>().convert(realLvl);
            cost = FindObjectOfType<Money>().convert(realCost);

            lvlText.text = lvl;
            costText.text = cost;
        }
    }
}
