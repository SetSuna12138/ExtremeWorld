﻿using Models;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data;
using Assets.Scripts.Services;

namespace Managers
{
    public class ItemManager : Singleton<ItemManager>
    {

        public Dictionary<int, Item> Items = new Dictionary<int, Item>();
        public void Init(List<NItemInfo> items)
        {
            this.Items.Clear();

            foreach (var info in items)
            {
                Item item = new Item(info);
                this.Items.Add(item.Id, item);
            }
            StatusService.Instance.RigisterStatusNofity(StatusType.Item, OnItemNotify);
        }

        bool OnItemNotify(NStatus status)
        {
            if(status.Action == StatusAction.Add)
            {
                this.AddItem(status.Id, status.Value);
            }
            if(status.Action == StatusAction.Delete)
            {
                this.RemoveItem(status.Id, status.Value);
            }
            return true;
        }

        void AddItem(int itemId, int count)
        {
            Item item = null;
            if(this.Items.TryGetValue(itemId, out item))
            {
                item.Count += count;
            }
            else
            {
                item = new Item(itemId, count);
                this.Items.Add(itemId, item);
            }
            BagManager.Instance.AddItem(itemId, count);
        }

        void RemoveItem(int itemId, int count)
        {
            if (!this.Items.ContainsKey(itemId))
            {
                return;
            }
            Item item = this.Items[itemId];
            if(item.Count < count)
                return;
            item.Count -= count;

            BagManager.Instance.RemoveItem(itemId, count);
            
        }

        public ItemDefine GetItem(int itemId)
        {
            return null;
        }

        public bool UseItem(int itemId)
        {
            return false;
        }

        public bool UseItenm(ItemDefine item)
        {
            return false;
        }
    }

}
