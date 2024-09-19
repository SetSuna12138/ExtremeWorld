using Common.Data;
using Managers;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


class UIShop : UIWindows
{
    public Text title;
    public Text money;

    public Transform[] itemRoot;
    ShopDefine shop;
    public GameObject shopItem;

    void Start()
    {
        StartCoroutine(InitItem());
    }
    
    IEnumerator InitItem()
    {
        int count = 0;
        int page = 0;
        foreach(var kv in DataManager.Instance.ShopItems[shop.ID])
        {
            if(kv.Value.Status > 0)
            {
                GameObject go = Instantiate(shopItem, itemRoot[page]);
                UIShopItem ui = go.GetComponent<UIShopItem>();
                ui.SetShopItem(kv.Key, kv.Value, this);
                count++;
                if(count > 10)
                {
                    count = 0;
                    page++;
                    itemRoot[page].gameObject.SetActive(true);
                }
            }
        }
        yield return null;
    }

    public void SetShop(ShopDefine shop)
    {
        this.shop = shop;
        this.title.text = shop.Name;
        this.money.text = User.Instance.CurrentCharacter.Gold.ToString();
    }

    public UIShopItem selectedItem;
    public void SelectShopItem(UIShopItem item)
    {
        if(selectedItem != null)
        {
            selectedItem.Selected = false;
        }
        selectedItem = item;
    }

    public void OnClickBuy()
    {
        if(this.selectedItem == null)
        {
            MessageBox.Show("请选择要购买的物体","购买提示");
        }
        if(!ShopManager.Instance.BuyItem(this.shop.ID, this.selectedItem.ShopItemID))
        {

        }
    }
}

