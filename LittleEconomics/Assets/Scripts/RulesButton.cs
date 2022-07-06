using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesButton : MonoBehaviour
{
    public Sprite[] Rules = new Sprite[5];
    public Button RuleButton;
    public int i = 1;
    
    public void OnClickButton()
    {      
        if (i < Rules.Length) 
        {
            RuleButton.image.sprite = Rules[i];
            i++;    
        } 
        else
        {
            RuleButton.gameObject.SetActive(false);
        }
    }
}
