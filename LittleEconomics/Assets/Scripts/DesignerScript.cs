using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DesignerScript : MonoBehaviour
{
    public List<Potion> Potions = new List<Potion>();

    public List<PotionsPanel> PanelPotions = new List<PotionsPanel>();
    public int maxCount = 15;
    public EventSystem es;

    public GameObject ThePotionObject;
    public GameObject PanelPotionMainObject;

    public InputField PotionName;
    public string PotionNameText;
    public Button PotionNameOk;

    public Image HealthIngredient;
    public Image IntellectIngredient;
    public Image StaminaIngredient;
    public Image CharismaIngredient;

    public static int HealthIngredientID;
    public static int IntellectIngredientID;
    public static int StaminaIngredientID;
    public static int CharismaIngredientID;

    public Button HealthPlus;
    public Button IntellectPlus;
    public Button StaminaPlus;
    public Button CharismaPlus;

    public Button HealthMinus;
    public Button IntellectMinus;
    public Button StaminaMinus;
    public Button CharismaMinus;

    public Text HealthPoints;
    public Text IntellectPoints;
    public Text StaminaPoints;
    public Text CharismaPoints;

    public Sprite[] HealthIngredients = new Sprite[4];
    public Sprite[] IntellectIngredients = new Sprite[4];
    public Sprite[] StaminaIngredients = new Sprite[4];
    public Sprite[] CharismaIngredients = new Sprite[4];

    public int HealthIngredientPoints = 1;
    public int IntellectIngredientPoints = 1;
    public int StaminaIngredientPoints = 1;
    public int CharismaIngredientPoints = 1;

    int PointsAll = 25;
    int PointsIn = 4;
    int PointsLeft = 21;

    public Text PointsText;
    public Image ThePotionImage;
    public Sprite PotionSprite; 
    public int r = 255;
    public int g = 255;
    public int b = 255;

    //public Button NewPotionButton;

    public int id = 0;
    public static int maxInDay = 0;

    public static bool needHealth;
    public static bool needIntellect;
    public static bool needStamina;
    public static bool needCharisma;

    public GameObject СauldronProduct;
    public GameObject СauldronOpen;

    public AudioSource theSoundDoPotion;
    public AudioSource theSoundSellPotion;

    void Update()
    {
        PotionNameText = PotionName.text;

        switch (HealthIngredientPoints)
        {
            case 1:
            case 2:
                HealthIngredient.sprite = HealthIngredients[0];
                needHealth = BagInventoryScript.HaveHealth1;
                HealthIngredientID = 1;
                break;

            case 3:
            case 4:
            case 5:
                HealthIngredient.sprite = HealthIngredients[1];
                needHealth = BagInventoryScript.HaveHealth2;
                HealthIngredientID = 2;
                break;

            case 6:
            case 7:
            case 8:
                HealthIngredient.sprite = HealthIngredients[2];
                needHealth = BagInventoryScript.HaveHealth3;
                HealthIngredientID = 3;
                break;

            case 9:
            case 10:
                HealthIngredient.sprite = HealthIngredients[3];
                needHealth = BagInventoryScript.HaveHealth4;
                HealthIngredientID = 4;
                break;

        }

        switch (IntellectIngredientPoints)
        {
            case 1:
            case 2:
                IntellectIngredient.sprite = IntellectIngredients[0];
                needIntellect = BagInventoryScript.HaveIntellect1;
                IntellectIngredientID = 5;
                break;

            case 3:
            case 4:
            case 5:
                IntellectIngredient.sprite = IntellectIngredients[1];
                needIntellect = BagInventoryScript.HaveIntellect2;
                IntellectIngredientID = 6;
                break;

            case 6:
            case 7:
            case 8:
                IntellectIngredient.sprite = IntellectIngredients[2];
                needIntellect = BagInventoryScript.HaveIntellect3;
                IntellectIngredientID = 7;
                break;

            case 9:
            case 10:
                IntellectIngredient.sprite = IntellectIngredients[3];
                needIntellect = BagInventoryScript.HaveIntellect4;
                IntellectIngredientID = 8;
                break;

        }

        switch (StaminaIngredientPoints)
        {
            case 1:
            case 2:
                StaminaIngredient.sprite = StaminaIngredients[0];
                needStamina = BagInventoryScript.HaveStamina1;
                StaminaIngredientID = 9;
                break;

            case 3:
            case 4:
            case 5:
                StaminaIngredient.sprite = StaminaIngredients[1];
                needStamina = BagInventoryScript.HaveStamina2;
                StaminaIngredientID = 10;
                break;

            case 6:
            case 7:
            case 8:
                StaminaIngredient.sprite = StaminaIngredients[2];
                needStamina = BagInventoryScript.HaveStamina3;
                StaminaIngredientID = 11;
                break;

            case 9:
            case 10:
                StaminaIngredient.sprite = StaminaIngredients[3];
                needStamina = BagInventoryScript.HaveStamina4;
                StaminaIngredientID = 12;
                break;

        }

        switch (CharismaIngredientPoints)
        {
            case 1:
            case 2:
                CharismaIngredient.sprite = CharismaIngredients[0];
                needCharisma = BagInventoryScript.HaveCharisma1;
                CharismaIngredientID = 13;
                break;

            case 3:
            case 4:
            case 5:
                CharismaIngredient.sprite = CharismaIngredients[1];
                needCharisma = BagInventoryScript.HaveCharisma2;
                CharismaIngredientID = 14;
                break;

            case 6:
            case 7:
            case 8:
                CharismaIngredient.sprite = CharismaIngredients[2];
                needCharisma = BagInventoryScript.HaveCharisma3;
                CharismaIngredientID = 15;
                break;

            case 9:
            case 10:
                CharismaIngredient.sprite = CharismaIngredients[3];
                needCharisma = BagInventoryScript.HaveCharisma4;
                CharismaIngredientID = 16;
                break;

        }

        if (needHealth)
        {
            HealthIngredient.color = new Color(1, 1, 1, 1);
        }
        else
        {
            HealthIngredient.color = new Color(1, 1, 1, 0.5F);
        }

        if (needIntellect)
        {
            IntellectIngredient.color = new Color(1, 1, 1, 1);
        }
        else
        {
            IntellectIngredient.color = new Color(1, 1, 1, 0.5F);
        }

        if (needStamina)
        {
            StaminaIngredient.color = new Color(1, 1, 1, 1);
        }
        else
        {
            StaminaIngredient.color = new Color(1, 1, 1, 0.5F);
        }

        if (needCharisma)
        {
            CharismaIngredient.color = new Color(1, 1, 1, 1);
        }
        else
        {
            CharismaIngredient.color = new Color(1, 1, 1, 0.5F);
        }
    }

    public void BuyСauldron()
    {
        BalanceScript.Balance -= 200;
        СauldronProduct.SetActive(false);
        СauldronOpen.SetActive(true);
    }

    public void NewPotion()
    {
        PointsAll = 25;
        PointsIn = 4;
        PointsLeft = 21;

        r = 255;
        g = 255;
        b = 255;

        HealthIngredientPoints = 1;
        IntellectIngredientPoints = 1;
        StaminaIngredientPoints = 1;
        CharismaIngredientPoints = 1;

        HealthIngredient.sprite = HealthIngredients[0];
        IntellectIngredient.sprite = IntellectIngredients[0];
        StaminaIngredient.sprite = StaminaIngredients[0];
        CharismaIngredient.sprite = CharismaIngredients[0];

        HealthPoints.text = HealthIngredientPoints.ToString();
        IntellectPoints.text = IntellectIngredientPoints.ToString();
        StaminaPoints.text = StaminaIngredientPoints.ToString();
        CharismaPoints.text = CharismaIngredientPoints.ToString();

        PotionName.text = "";
        PotionNameText = "";

        PointsIn = HealthIngredientPoints + IntellectIngredientPoints + StaminaIngredientPoints + CharismaIngredientPoints;
        PointsLeft = PointsAll - PointsIn;
        PointsText.text = PointsLeft + "/" + PointsAll;

    }

    public void PointsPlusHealth()
    {
        if(PointsLeft > 0)
        {
            if (HealthIngredientPoints < 10)
            {
                HealthIngredientPoints++;
                Ingredients();
            }
        }
    }

    public void PointsPlusIntellect()
    {
        if (PointsLeft > 0)
        {
            if (IntellectIngredientPoints < 10)
            {
                IntellectIngredientPoints++;
                Ingredients();
            }
        }
    }

    public void PointsPlusStamina()
    {
        if (PointsLeft > 0)
        {
            if (StaminaIngredientPoints < 10)
            {
                StaminaIngredientPoints++;
                Ingredients();
            }
        }
    }

    public void PointsPlusCharisma()
    {
        if (PointsLeft > 0)
        {
            if (CharismaIngredientPoints < 10)
            {
                CharismaIngredientPoints++;
                Ingredients();
            }
        }
    }

    public void PointsMinusHealth()
    {
        if (HealthIngredientPoints > 1)
        {
            HealthIngredientPoints--;
            Ingredients();
        }
    }

    public void PointsMinusIntellect()
    {
        if (IntellectIngredientPoints > 1)
        {
            IntellectIngredientPoints--;
            Ingredients();
        }
    }

    public void PointsMinusStamina()
    {
        if (StaminaIngredientPoints > 1)
        {
            StaminaIngredientPoints--;
            Ingredients();
        }
    }

    public void PointsMinusCharisma()
    {
        if (CharismaIngredientPoints > 1)
        {
            CharismaIngredientPoints--;
            Ingredients();
        }
    }

    public void Ingredients()
    {
        PointsIn = HealthIngredientPoints + IntellectIngredientPoints + StaminaIngredientPoints + CharismaIngredientPoints;
        PointsLeft = PointsAll - PointsIn;
        PointsText.text = PointsLeft + "/" + PointsAll;

        HealthPoints.text = HealthIngredientPoints.ToString();
        IntellectPoints.text = IntellectIngredientPoints.ToString();
        StaminaPoints.text = StaminaIngredientPoints.ToString();
        CharismaPoints.text = CharismaIngredientPoints.ToString();

        if (g > 20)
        {
            ThePotionImage.color = new Color(1, g / 255.0F, 1);
            g -= 1;
        }
        else if (r > 30) 
        {
            ThePotionImage.color = new Color(r / 255.0F, g / 255.0F, 1);
            r -= 1;
        }
        else if (b > 40)
        {
            ThePotionImage.color = new Color(r / 255.0F, g / 255.0F, b / 255.0F);
            b -= 1;
        }
    }


    public void DoPotion()
    {
        if (maxInDay < 10)
        {
            if (PointsIn == 25 && HealthIngredientPoints >= 1 && IntellectIngredientPoints >= 1 && StaminaIngredientPoints >= 1 && CharismaIngredientPoints >= 1)
            {
                if (needHealth && needIntellect && needStamina && needCharisma) 
                {
                    theSoundDoPotion.Play();
                    Potions.Add(new Potion(id, HealthIngredientPoints, IntellectIngredientPoints, StaminaIngredientPoints, CharismaIngredientPoints, PotionNameText, r, g, b, PotionSprite));

                    GameObject newPotion = Instantiate(ThePotionObject, PanelPotionMainObject.transform) as GameObject;
                    newPotion.name = id.ToString();
                    PotionsPanel ii = new PotionsPanel();
                    ii.itemGameObject = newPotion;
                    RectTransform rt = newPotion.GetComponent<RectTransform>();
                    rt.localPosition = new Vector3(0, 0, 0);
                    rt.localScale = new Vector3(1, 1, 1);
                    newPotion.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
                    ii.itemGameObject.GetComponent<Image>().sprite = Potions[id].PotionImage;//nnn
                    ii.itemGameObject.GetComponent<Image>().color = new Color(r / 255.0F, g / 255.0F, b / 255.0F); ;
                    ii.itemGameObject.GetComponentInChildren<Text>().text = Potions[id].PotionName;//ddd
                    PanelPotions.Add(ii);
                    newPotion.SetActive(true);

                    id++;
                    maxInDay++;
                }
            }
        }
    }

    public void SellPotion()
    {
        theSoundSellPotion.Play();

        int SellId = int.Parse(es.currentSelectedGameObject.name);
        PanelPotions[SellId].itemGameObject.SetActive(false);

        switch (TimeScript.GameDays)
        {
            case 30:
                if (Potions[SellId].PotionHealth >= 9 && Potions[SellId].PotionIntellect == 5 && Potions[SellId].PotionStamina == 5 && Potions[SellId].PotionCharisma == 5)
                {
                    BalanceScript.Balance += 500;
                    BalanceScript.My1 += 500;
                }
                else
                {
                    BalanceScript.Balance += 300;
                    BalanceScript.My1 += 300;
                }
                break;

            case 31:
                if (Potions[SellId].PotionHealth >= 3 && Potions[SellId].PotionIntellect >= 9 && Potions[SellId].PotionStamina >= 7 && Potions[SellId].PotionCharisma >= 1)
                {
                    BalanceScript.Balance += 600;
                    BalanceScript.My2 += 600;
                }
                else
                {
                    BalanceScript.Balance += 300;
                    BalanceScript.My2 += 300;
                }
                break;

            case 1:
                if (Potions[SellId].PotionHealth >= 3 && Potions[SellId].PotionIntellect >= 1 && Potions[SellId].PotionStamina >= 9 && Potions[SellId].PotionCharisma >= 9)
                {
                    BalanceScript.Balance += 700;
                    BalanceScript.My3 += 700;
                }
                else
                {
                    BalanceScript.Balance += 300;
                    BalanceScript.My3 += 300;
                }
                break;

            case 2:
                if (Potions[SellId].PotionHealth >= 9 && Potions[SellId].PotionIntellect >= 3 && Potions[SellId].PotionStamina >= 9 && Potions[SellId].PotionCharisma >= 1)
                {
                    BalanceScript.Balance += 700;
                    BalanceScript.My4 += 700;
                }
                else
                {
                    BalanceScript.Balance += 300;
                    BalanceScript.My4 += 300;
                }
                break;

            case 3:
                if (Potions[SellId].PotionHealth >= 9 && Potions[SellId].PotionIntellect >= 9 && Potions[SellId].PotionStamina >= 1 && Potions[SellId].PotionCharisma >= 3)
                {
                    BalanceScript.Balance += 700;
                    BalanceScript.My5 += 700;
                }
                else
                {
                    BalanceScript.Balance += 300;
                    BalanceScript.My5 += 300;
                }
                break;

            case 4:
                if (Potions[SellId].PotionHealth >= 1 && Potions[SellId].PotionIntellect >= 9 && Potions[SellId].PotionStamina >= 3 && Potions[SellId].PotionCharisma >= 9)
                {
                    BalanceScript.Balance += 800;
                    BalanceScript.My6 += 800;
                }
                else
                {
                    BalanceScript.Balance += 300;
                    BalanceScript.My6 += 300;
                }
                break;

            case 5:
                if (Potions[SellId].PotionHealth >= 6 && Potions[SellId].PotionIntellect >= 6 && Potions[SellId].PotionStamina >= 6 && Potions[SellId].PotionCharisma >= 6)
                {
                    BalanceScript.Balance += 650;
                    BalanceScript.My7 += 650;
                }
                else
                {
                    BalanceScript.Balance += 300;
                    BalanceScript.My7 += 300;
                }
                break;
        }
    }
}

[System.Serializable]

public class Potion
{
    public int PotionID;
    public int PotionHealth;
    public int PotionIntellect;
    public int PotionStamina;
    public int PotionCharisma;
    public string PotionName;
    public int PotionR;
    public int PotionG;
    public int PotionB;
    public Sprite PotionImage;

    public Potion(int id, int Health, int Intellect, int Stamina, int Charisma, string theName, int r, int g, int b, Sprite theImage)
    {
        PotionID = id;
        PotionHealth = Health;
        PotionIntellect = Intellect;
        PotionStamina = Stamina;
        PotionCharisma = Charisma;
        PotionName = theName;
        PotionR = r;
        PotionG = g;
        PotionB = b;
        PotionImage = theImage;
    }
}

public class PotionsPanel
{
    public int id;
    public GameObject itemGameObject;
}