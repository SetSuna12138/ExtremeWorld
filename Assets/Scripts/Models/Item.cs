using Common.Data;
using Managers;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Item
    {
        public int Id;
        public int Count;
        public ItemDefine Define;


        //public Item(NItemInfo item)
        //{
        //    this.Id = item.Id;
        //    this.Count = item.Count;
        //    this.Define = DataManager.Instance.Items[Id];
        //}
        public Item(NItemInfo item) :
            this(item.Id, item.Count)
        {
        }

        public Item(int id, int count)
        {
            Id = id;
            Count = count;
            Define = DataManager.Instance.Items[this.Id];
        }

        

    }
}
