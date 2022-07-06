using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BagInventoryScript : MonoBehaviour
{
    public InventoryBase data;

    public List<ItemInventory> items = new List<ItemInventory>();

    public GameObject gameObjectShow;
    public GameObject InventoryMainObject;

    public int maxCount;

    public Camera cam;
    public EventSystem es;

    public int currentID;
    public ItemInventory currentItem;

    public RectTransform movingObject;
    public Vector3 offset;

    //public GameObject BG;

    public GameObject NoBalancePanel;

    public static bool HaveHealth1;
    public static bool HaveHealth2;
    public static bool HaveHealth3;
    public static bool HaveHealth4;

    public static bool HaveIntellect1;
    public static bool HaveIntellect2;
    public static bool HaveIntellect3;
    public static bool HaveIntellect4;

    public static bool HaveStamina1;
    public static bool HaveStamina2;
    public static bool HaveStamina3;
    public static bool HaveStamina4;

    public static bool HaveCharisma1;
    public static bool HaveCharisma2;
    public static bool HaveCharisma3;
    public static bool HaveCharisma4;

    public Text Health1Price;
    public Text Charisma1Price;
    //float time = 0;

    //public int id;
    //public Item item;

    public void Start()
    {
        if(items.Count == 0)
        {
            AddGraphics();
            Debug.Log("Старт");
        }

        //for (int i = 0; i < maxCount; i++)//тест
        //{
        //    AddItem(i, data.items[Random.Range(0, data.items.Count)], Random.Range(1, 16));
        //}

        UpdateInventory(); 
    }

    public void Update()
    {
        if (currentID != -1) 
        {
            MoveObject();
        }

        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    BG.SetActive(!BG.activeSelf);
        //    if (BG.activeSelf)
        //    {
                UpdateInventory();
        //    }
        //}

        if (TimeScript.GameDays == 3) //3
        {
            data.items[1].price = 60;
            data.items[13].price = 60;
            Health1Price.text = "60";
            Charisma1Price.text = "60";
        }
        
    }

    public void SearchForSameItem(Item item, int count)
    {
        Debug.Log("серчворсеймитем");
        for (int i = 0; i < maxCount; i++) 
        {
            if (items[i].id == item.id) 
            {
                if (items[i].count < 30) 
                {
                    items[i].count += count;

                    if (items[i].count <= 0)
                    {
                        AddItem(i, data.items[0], 0);

                        switch (item.id)
                        {
                            case 1:
                                HaveHealth1 = false;
                                break;

                            case 2:
                                HaveHealth2 = false;
                                break;

                            case 3:
                                HaveHealth3 = false;
                                break;

                            case 4:
                                HaveHealth4 = false;
                                break;

                            case 5:
                                HaveIntellect1 = false;
                                break;

                            case 6:
                                HaveIntellect2 = false;
                                break;

                            case 7:
                                HaveIntellect3 = false;
                                break;

                            case 8:
                                HaveIntellect4 = false;
                                break;

                            case 9:
                                HaveStamina1 = false;
                                break;

                            case 10:
                                HaveStamina2 = false;
                                break;

                            case 11:
                                HaveStamina3 = false;
                                break;

                            case 12:
                                HaveStamina4 = false;
                                break;

                            case 13:
                                HaveCharisma1 = false;
                                break;

                            case 14:
                                HaveCharisma2 = false;
                                break;

                            case 15:
                                HaveCharisma3 = false;
                                break;

                            case 16:
                                HaveCharisma4 = false;
                                break;
                        }
                        

                        //проверку на айди мб чтоб нидхелф обнулялся раз нет уже
                    }

                    if (items[i].count > 30)
                    {
                        count = items[i].count - 30;
                        items[i].count = 15;
                    }
                    else
                    {
                        count = 0;
                        i = maxCount;
                    }
                }
            }
        }
        if (count > 0) 
        {
            for (int i = 0; i < maxCount; i++) 
            {
                if (items[i].id == 0) 
                {
                    AddItem(i, item, count);
                    i = maxCount;
                }
            }
        }
        //if (count < 0)
        //{
        //    for (int i = 0; i < maxCount; i++)
        //    {
        //        if (items[i].id == item.id)
        //        {
        //            AddItem(i, data.items[0], 0);
        //        }
        //    }
        //    //AddItem(i, data.items[0], 0);
        //}
        //else
        //{
        //    AddItem(item.id, data.items[0], 0);
        //}
    }

    public void AddItem(int id, Item item, int count)
    {
        Debug.Log("аддитем");
        items[id].id = item.id;
        items[id].count = count;
        items[id].itemGameObject.GetComponent<Image>().sprite = item.image;

        if (maxCount > 1 && item.id != 0)
        {
            items[id].itemGameObject.GetComponentInChildren<Text>().text = count.ToString();
        }
        else
        {
            items[id].itemGameObject.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddInventoryItem(int id, ItemInventory invItem)
    {
        Debug.Log("адд инвентори");
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].itemGameObject.GetComponent<Image>().sprite = data.items[invItem.id].image;

        if (invItem.count > 1 && invItem.id != 0)
        {
            items[id].itemGameObject.GetComponentInChildren<Text>().text = invItem.count.ToString();
        }
        else
        {
            items[id].itemGameObject.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddGraphics()
    {
        Debug.Log("аддграфик");
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjectShow, InventoryMainObject.transform) as GameObject;
            newItem.name = i.ToString();
            ItemInventory ii  = new ItemInventory();
            ii.itemGameObject = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(ii);
        }
    }

    public void UpdateInventory()
    {
        for( int i = 0; i < maxCount; i++)
        {
            if (items[i].id != 0 && items[i].count > 1)
            {
                items[i].itemGameObject.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].itemGameObject.GetComponentInChildren<Text>().text = "";
            }

            items[i].itemGameObject.GetComponent<Image>().sprite = data.items[items[i].id].image;
        }
    }


    public void SelectObject()
    {
        //Debug.Log("селектобджект");
        if (currentID == -1)  
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            Debug.Log("вот тут работает иф");
            currentItem = CopyItemInventory(items[currentID]);

            if (data.items[currentItem.id].id != 0)
            {
                Debug.Log("сработал иф"+ data.items[currentItem.id].id);
                movingObject.gameObject.SetActive(true);
                movingObject.GetComponent<Image>().sprite = data.items[currentItem.id].image;

                AddItem(currentID, data.items[0], 0);
            }
            else
            {
                currentID = -1;
            }


        }
        else
        {
            if (data.items[currentItem.id].id != 0)
            {
                ItemInventory II = items[int.Parse(es.currentSelectedGameObject.name)];

                if (currentItem.id != II.id)
                {
                    AddInventoryItem(currentID, II);

                    AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
                }
                else
                {
                    if (II.count + currentItem.count <= 30)
                    {
                        II.count += currentItem.count;
                    }
                    else
                    {
                        AddItem(currentID, data.items[II.id], II.count + currentItem.count - 30);

                        II.count = 30;
                    }

                    if (II.id != 0)
                    {
                        II.itemGameObject.GetComponentInChildren<Text>().text = II.count.ToString();
                    }
                }
            }

            currentID = -1;

            movingObject.gameObject.SetActive(false);
        }
    }

    public void MoveObject()
    {
        //Debug.Log("мувобджект");
        //if (currentID != 0)
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }

    public ItemInventory CopyItemInventory(ItemInventory old)
    {
        //Debug.Log("копиитем");
        ItemInventory New = new ItemInventory();

        New.id = old.id;
        New.itemGameObject = old.itemGameObject;
        New.count = old.count;

        return New;
    }

    public void BuyItem()
    {
        int id = int.Parse(es.currentSelectedGameObject.name);
        Item item = data.items[id];
        int price = item.price;
        if (price <= BalanceScript.Balance)
        {
            //int price = int.Parse(es.currentSelectedGameObject.text);
            ///// тут про цену
            BalanceScript.Balance -= price;
            SearchForSameItem(item, 1);
            UpdateInventory();

            switch (data.items[id].id)
            {
                case 1:
                    Debug.Log("это хелф1");
                    HaveHealth1 = true;
                    break;

                case 2:
                    Debug.Log("это хелф2");
                    HaveHealth2 = true;
                    break;

                case 3:
                    Debug.Log("это хелф3");
                    HaveHealth3 = true;
                    break;

                case 4:
                    Debug.Log("это хелф4");
                    HaveHealth4 = true;
                    break;

                case 5:
                    Debug.Log("это интеллект1");
                    HaveIntellect1 = true;
                    break;

                case 6:
                    Debug.Log("это интеллект2");
                    HaveIntellect2 = true;
                    break;

                case 7:
                    Debug.Log("это интеллект3");
                    HaveIntellect3 = true;
                    break;

                case 8:
                    Debug.Log("это интеллект 4");
                    HaveIntellect4 = true;
                    break;

                case 9:
                    Debug.Log("это стамина1");
                    HaveStamina1 = true;
                    break;

                case 10:
                    Debug.Log("это стамина2");
                    HaveStamina2 = true;
                    break;

                case 11:
                    Debug.Log("это стамина3");
                    HaveStamina3 = true;
                    break;

                case 12:
                    Debug.Log("это стамина4");
                    HaveStamina4 = true;
                    break;

                case 13:
                    Debug.Log("это харизма1");
                    HaveCharisma1 = true;
                    break;

                case 14:
                    Debug.Log("это харизма2");
                    HaveCharisma2 = true;
                    break;

                case 15:
                    Debug.Log("это харизма3");
                    HaveCharisma3 = true;
                    break;

                case 16:
                    Debug.Log("это харизма4");
                    HaveCharisma4 = true;
                    break;


            }
        }
        else
        {
            Debug.Log("нет деняк");
            NoBalancePanel.SetActive(true);
            //time = 2;
        }
    }

    //public static RemoveItem(int ID)
    //{
    //    Debug.Log("ремувитем");
    //    items[id].id = ID;
    //    items[id].count--;
    //    //items[id].itemGameObject.GetComponent<Image>().sprite = item.image;
    //    items.Remove(items[ID]);
    //    if (maxCount > 1 && item.id != 0)
    //    {
    //        items[id].itemGameObject.GetComponentInChildren<Text>().text = count.ToString();
    //    }
    //    else
    //    {
    //        items[id].itemGameObject.GetComponentInChildren<Text>().text = "";
    //    }

    //}

    //public void RemoveInventoryItem(int id)
    //{
    //    ItemInventory II = items[id];
    //    Debug.Log("ремув инвентори");
    //    items[id].id = invItem.id;
    //    items[id].count = invItem.count;
    //    items[id].count--;
    //    if (items[id].count > 0)
    //    {
    //        items[id].itemGameObject.GetComponent<Image>().sprite = data.items[invItem.id].image;

    //        if (invItem.count > 1 && invItem.id != 0)
    //        {
    //            items[id].itemGameObject.GetComponentInChildren<Text>().text = invItem.count.ToString();
    //        }
    //        else
    //        {
    //            items[id].itemGameObject.GetComponentInChildren<Text>().text = "";
    //        }
    //    }
    //    else
    //    {
    //        items.Remove(items[id]);
    //    }
    //}

    //public void SearchForSameItemForRemovw(Item item, int count)
    //{
    //    Debug.Log("серчворсеймитем");
    //    for (int i = 0; i < maxCount; i++)
    //    {
    //        if (items[i].id == item.id)
    //        {
    //            if (items[i].count < 30)
    //            {
    //                items[i].count += count;

    //                if (items[i].count > 30)
    //                {
    //                    count = items[i].count - 30;
    //                    items[i].count = 15;
    //                }
    //                else
    //                {
    //                    count = 0;
    //                    i = maxCount;
    //                }
    //            }
    //        }
    //    }
    //    if (count > 0)
    //    {
    //        for (int i = 0; i < maxCount; i++)
    //        {
    //            if (items[i].id == 0)
    //            {
    //                RemoveItem(i, item, count);
    //                i = maxCount;
    //            }
    //        }
    //    }
    //}

    public void RemoveItem(int id)
    {
        Item item = data.items[id];
        //Debug.Log("убираем с айди "+ items[id].id+ items[id].count);
        //item.count--;
        //items = data.items[id];
        SearchForSameItem(item, -1);
        UpdateInventory();
            //AddItem(currentID, data.items[II.id], II.count + currentItem.count - 30);
            
        //items[id].itemGameObject.GetComponentInChildren<Text>().text = items[id].count.ToString();
        

        //if (item.count == 0)
        //{
        //    Debug.Log("выкидываем из итемс ");
        //    //items.Remove(items[id]);
        //    AddItem(item.id, data.items[0], 0);
        //}
        //Debug.Log("аддитем");
        //items[id].id = item.id;
        //items[id].count = count;
        //items[id].itemGameObject.GetComponent<Image>().sprite = item.image;

        //if (maxCount > 1 && item.id != 0)
        //{
        //    items[id].itemGameObject.GetComponentInChildren<Text>().text = count.ToString();
        //}
        //else
        //{
        //    items[id].itemGameObject.GetComponentInChildren<Text>().text = "";
        //}
    }

    public void RemoveFromInv()
    {
        if (DesignerScript.needHealth && DesignerScript.needIntellect && DesignerScript.needStamina && DesignerScript.needCharisma) 
        {
            RemoveItem(DesignerScript.HealthIngredientID);
            RemoveItem(DesignerScript.IntellectIngredientID);
            RemoveItem(DesignerScript.StaminaIngredientID);
            RemoveItem(DesignerScript.CharismaIngredientID);
        }
    }


}

[System.Serializable]

public class ItemInventory
{
    public int id;
    public GameObject itemGameObject;
    public int count;
}
