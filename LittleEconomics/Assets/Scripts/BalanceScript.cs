using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceScript : MonoBehaviour
{
    public static int Balance = 2000;
    public Text BalanceText;
    public GameObject NoBalancePanel;
    public GameObject TimeBalanceCanvas;

    public GameObject StatPanel;

    public Slider PB1;
    public Slider PB2;
    public Slider PB3;
    public Slider PB4;
    public Slider PB5;
    public Slider PB6;
    public Slider PB7;

    public Text Day1;
    public Text Day2;
    public Text Day3;
    public Text Day4;
    public Text Day5;
    public Text Day6;
    public Text Day7;
    public Text DayAll;

    public static int Max1 = 5000;
    public static int Max2 = 6000;
    public static int Max3 = 7000;
    public static int Max4 = 7000;
    public static int Max5 = 7000;
    public static int Max6 = 8000;
    public static int Max7 = 6500;

    public static int My1 = 0;
    public static int My2 = 0;
    public static int My3 = 0;
    public static int My4 = 0;
    public static int My5 = 0;
    public static int My6 = 0;
    public static int My7 = 0;

    public static int Stat1 = 0;
    public static int Stat2 = 0;
    public static int Stat3 = 0;
    public static int Stat4 = 0;
    public static int Stat5 = 0;
    public static int Stat6 = 0;
    public static int Stat7 = 0;
    public static int StatAll = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BalanceText.text = "" + Balance.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            NoBalancePanel.SetActive(false);
        }

        if (TimeScript.GameDays == 6)
        {
            TheStats();
        }
    }

    public void TheStats()
    {
        TimeBalanceCanvas.SetActive(false);

        Stat1 = My1 / (Max1 / 100);
        Stat2 = My2 / (Max2 / 100);
        Stat3 = My3 / (Max3 / 100);
        Stat4 = My4 / (Max4 / 100);
        Stat5 = My5 / (Max5 / 100);
        Stat6 = My6 / (Max6 / 100);
        Stat7 = My7 / (Max7 / 100);

        StatAll = (My1 + My2 + My3 + My4 + My5 + My6 + My7) / ((Max1 + Max2 + Max3 + Max4 + Max5 + Max6 + Max7) / 100);

        Day1.text = My1 + "/" + Max1;
        Day2.text = My2 + "/" + Max2;
        Day3.text = My3 + "/" + Max3;
        Day4.text = My4 + "/" + Max4;
        Day5.text = My5 + "/" + Max5;
        Day6.text = My6 + "/" + Max6;
        Day7.text = My7 + "/" + Max7;

        DayAll.text = "За всю игру вы заработали " + StatAll + "% от максимально возможной прибыли";
        
        PB1.value = Stat1;
        PB2.value = Stat2;
        PB3.value = Stat3;
        PB4.value = Stat4;
        PB5.value = Stat5;
        PB6.value = Stat6;
        PB7.value = Stat7;

        StatPanel.SetActive(true);

    }
}
