using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CompetitorScript : MonoBehaviour
{
    public Image CompImage;
    public Sprite[] Comps = new Sprite[12];
    public GameObject CompPanel;
    public EventSystem es;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CompPanel.SetActive(false);
        }
    }

    public void Comp()
    {
        int id = int.Parse(es.currentSelectedGameObject.name);
        CompImage.sprite = Comps[id-1];
        CompPanel.SetActive(true);
    }

}
