using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewspaperScript : MonoBehaviour
{
    public Image NewspaperImage;
    public Sprite[] Newspapers = new Sprite[7];

    void Update()
    {
        switch (TimeScript.GameDays)
        {
            case 30: 
                NewspaperImage.sprite = Newspapers[0];
                break;

            case 31:
                NewspaperImage.sprite = Newspapers[1];
                break;

            case 1:
                NewspaperImage.sprite = Newspapers[2];
                break;

            case 2:
                NewspaperImage.sprite = Newspapers[3];
                break;

            case 3:
                NewspaperImage.sprite = Newspapers[4];
                break;

            case 4:
                NewspaperImage.sprite = Newspapers[5];
                break;

            case 5:
                NewspaperImage.sprite = Newspapers[6];
                break;
        }
    }
}
