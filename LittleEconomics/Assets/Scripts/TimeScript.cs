using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
 
    public float GameSeconds;
    public float GameMinutes;
    public static int GameDays = 30;
    public static int GameMonth = 8;

    public int IntSeconds;
    public int IntMinutes;

    string stringSeconds;
    string stringMinutes;
    string stringDays;
    string stringMonth;

    public Text TextTimer;

    void Update()
    {

        GameSeconds = GameSeconds + Time.deltaTime;

        IntSeconds = (int)GameSeconds;
        IntMinutes = (int)GameMinutes;
        stringSeconds = IntSeconds.ToString();
        stringMinutes = IntMinutes.ToString();
        stringDays = GameDays.ToString();
        stringMonth = GameMonth.ToString();

        if (GameDays < 10)
        {
            if (GameMinutes < 10)
            {
                if (GameSeconds < 10)
                {
                    TextTimer.text = "0" + stringMinutes + ":0" + stringSeconds + "\n0" + stringDays + ".0" + stringMonth + ".1827";
                }
                else
                {
                    TextTimer.text = "0" + stringMinutes + ":" + stringSeconds + "\n0" + stringDays + ".0" + stringMonth + ".1827";
                }
            }
            else
            {
                if (GameSeconds < 10)
                {
                    TextTimer.text = "" + stringMinutes + ":0" + stringSeconds + "\n0" + stringDays + ".0" + stringMonth + ".1827";
                }
                else
                {
                    TextTimer.text = "" + stringMinutes + ":" + stringSeconds + "\n0" + stringDays + ".0" + stringMonth + ".1827";
                }
            }
        }
        else
        {
            if (GameMinutes < 10)
            {
                if (GameSeconds < 10)
                {
                    TextTimer.text = "0" + stringMinutes + ":0" + stringSeconds + "\n" + stringDays + ".0" + stringMonth + ".1827";
                }
                else
                {
                    TextTimer.text = "0" + stringMinutes + ":" + stringSeconds + "\n" + stringDays + ".0" + stringMonth + ".1827";
                }
            }
            else
            {
                if (GameSeconds < 10)
                {
                    TextTimer.text = "" + stringMinutes + ":0" + stringSeconds + "\n" + stringDays + ".0" + stringMonth + ".1827";
                }
                else
                {
                    TextTimer.text = "" + stringMinutes + ":" + stringSeconds + "\n" + stringDays + ".0" + stringMonth + ".1827";
                }
            }
        }

        if (GameSeconds >= 60.0f)
        {
            GameMinutes = GameMinutes + 1.0f;
            GameSeconds = 0.0f;
        }

        if (GameMinutes >= 24.0f)
        {
            GameMinutes = 0.0f;
            GameDays++;
            DesignerScript.maxInDay = 0;
            switch (GameDays)
            {
                case 31:
                    BalanceScript.Balance += 1000;
                    break;

                case 1:
                    BalanceScript.Balance += 1000;
                    break;

                case 2:
                    BalanceScript.Balance += 500;
                    break;

                case 3:
                    BalanceScript.Balance += 500;
                    break;

                case 4:
                    BalanceScript.Balance += 500;
                    break;

                case 5:
                    BalanceScript.Balance += 500;
                    break;
            }
        }

        if (GameDays > 31)
        {
            GameMonth++;
            GameDays = 1;
        }
    }

    public void SkipDay()
    {
        GameDays++;
        GameSeconds = 0.0f;
        GameMinutes = 0.0f;
        DesignerScript.maxInDay = 0;

        switch (GameDays)
        {
            case 31:
                BalanceScript.Balance += 1000;
                break;

            case 1:
                BalanceScript.Balance += 1000;
                break;

            case 2:
                BalanceScript.Balance += 500;
                break;

            case 3:
                BalanceScript.Balance += 500;
                break;

            case 4:
                BalanceScript.Balance += 500;
                break;

            case 5:
                BalanceScript.Balance += 500;
                break;
        }
    }

}
