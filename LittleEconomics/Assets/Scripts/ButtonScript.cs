using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject MapCanvas;
    public GameObject MarketCanvas;
    public GameObject ShopCanvas;
    public GameObject SettingsCanvas;
    public GameObject NewspaperCanvas;
    public GameObject BagCanvas; 
    public GameObject HomeCanvas;
    public GameObject DesignerCanvas;
    public GameObject SellPotionPanel;
    public GameObject TimeBalanceCanvas;
    public GameObject StatsCanvas;

    void Update()
    {
        if(TimeScript.GameDays == 6)
        {
            MapCanvas.SetActive(false);
            MarketCanvas.SetActive(false);
            MenuCanvas.SetActive(false);
            ShopCanvas.SetActive(false);
            SettingsCanvas.SetActive(false);
            NewspaperCanvas.SetActive(false);
            BagCanvas.SetActive(false);
            HomeCanvas.SetActive(false);
            DesignerCanvas.SetActive(false);
            SellPotionPanel.SetActive(false);
            //TimeBalanceCanvas.SetActive(false);
            //StatsCanvas.SetActive(true);
        }
    }

    public void Close()
    {
        Application.Quit();
    }

    public void loadMenu()
    {
        MapCanvas.SetActive(false);
        MarketCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        ShopCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        NewspaperCanvas.SetActive(false);
        BagCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        DesignerCanvas.SetActive(false);
    }

    public void loadMap()
    {
        MapCanvas.SetActive(true);
        MarketCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        NewspaperCanvas.SetActive(false);
        BagCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        DesignerCanvas.SetActive(false);
    }

    public void loadMarket()
    {
        MapCanvas.SetActive(false);
        MarketCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        NewspaperCanvas.SetActive(false);
        BagCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        DesignerCanvas.SetActive(false);
    }

    public void loadShop()
    {
        MapCanvas.SetActive(false);
        MarketCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        ShopCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
        NewspaperCanvas.SetActive(false);
        BagCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        DesignerCanvas.SetActive(false);
    }

    public void loadSettings()
    {
        MapCanvas.SetActive(false);
        MarketCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
        NewspaperCanvas.SetActive(false);
        BagCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        DesignerCanvas.SetActive(false);
    }

    public void loadNewspaper()
    {
        MapCanvas.SetActive(false);
        MarketCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        NewspaperCanvas.SetActive(true);
        BagCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        DesignerCanvas.SetActive(false);
    }

    public void loadBag()
    {
        BagCanvas.SetActive(true);
    }

    public void ExitBag()
    {
        BagCanvas.SetActive(false);
    }

    public void loadSellPotionPanel()
    {
        SellPotionPanel.SetActive(true);
    }

    public void ExitSellPotionPanel()
    {
        SellPotionPanel.SetActive(false); 
    }

    public void loadHome()
    {
        MapCanvas.SetActive(false);
        MarketCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        NewspaperCanvas.SetActive(false);
        BagCanvas.SetActive(false);
        HomeCanvas.SetActive(true);
        DesignerCanvas.SetActive(false);
    }

    public void loadDesigner()
    {
        MapCanvas.SetActive(false);
        MarketCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        NewspaperCanvas.SetActive(false);
        BagCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        DesignerCanvas.SetActive(true);
    }

}
