using Common.Data;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
class UIShopItem : MonoBehaviour, ISelectHandler
{
    public Image icon;
    public Text title;
    public Text count;
    public Text price;
    public Text limitClass;

    public Image backgroound;
    public Sprite normalBag;
    public Sprite selectedBag;

    private bool selected;
    public bool Selected
    {
        get { return selected; }
        set
        {
            selected = value;
            this.backgroound.overrideSprite = selected ? selectedBag : normalBag;
        }
    }

    public int ShopItemID { get; set; }
    private UIShop shop;
    private ItemDefine item;
    private ShopItemDefine ShopItem { get; set; }

    void Start()
    {

    }

    public void SetShopItem(int id, Common.Data.ShopItemDefine shopItem, UIShop owner)
    {
        this.shop = owner;
        this.ShopItemID = id;
        this.ShopItem = shopItem;
        this.item = DataManager.Instance.Items[this.ShopItemID];

        this.title.text = this.item.Name;
        this.count.text = "x" + ShopItem.Count.ToString();
        this.price.text = shopItem.Price.ToString();
        this.icon.overrideSprite = Resloader.Load<Sprite>(item.Icon);
        this.limitClass.text = this.item.LimitClass.ToString();

    }

    public void OnSelect(BaseEventData eventData)
    {
        if (Selected != true)
            this.Selected = true;
        else
            this.Selected = false;

        this.shop.selectedItem = this;
    }
}
