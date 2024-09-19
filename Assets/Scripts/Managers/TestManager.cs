using Common.Data;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Managers
{
    class TestManager : Singleton<TestManager>
    {
        public void Init()
        {
            NPCManager.Instance.RegisterNpcEvent(Common.Data.NpcDefine.NpcFunction.InvokeShop, OnNpcInvokeShop);
            NPCManager.Instance.RegisterNpcEvent(Common.Data.NpcDefine.NpcFunction.InvokeInsrance, OnNpcInvokeInsrance);
        } 

        private bool OnNpcInvokeShop(NpcDefine npc)
        {
            UITest uITest = UIManager.Instance.Show<UITest>();
            uITest.SetTitle(npc.Name);
            return true;
        }

        private bool OnNpcInvokeInsrance(NpcDefine npc)
        {

            MessageBox.Show("点击了" + npc.Name);
            return true;
        }
    }
}
