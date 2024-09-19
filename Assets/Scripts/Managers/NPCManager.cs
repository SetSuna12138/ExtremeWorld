using Common.Data;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Managers
{
    class NPCManager : Singleton<NPCManager>
    {

        public delegate bool ActionHander(NpcDefine npc);
        Dictionary<NpcDefine.NpcFunction, ActionHander> eventMap = new Dictionary<NpcDefine.NpcFunction, ActionHander> ();

        public void RegisterNpcEvent(NpcDefine.NpcFunction function, ActionHander action)
        {
            if (!eventMap.ContainsKey(function))
            {
                eventMap[function] = action;
            }
            else
            {
                eventMap[function] += action;
            }
        }
        public NpcDefine GetNpcDefine(int npcId)
        {
            NpcDefine npc = null;
            DataManager.Instance.Npcs.TryGetValue(npcId, out npc);
            return npc;
        }

        public bool Interative(int npcId)
        {
            if (DataManager.Instance.Npcs.ContainsKey(npcId))
            {
                var npc = DataManager.Instance.Npcs[npcId];
                return Interative(npc);
            }
            return false;
        }

        public bool Interative(NpcDefine npc)
        {
            if (npc.Type == NpcDefine.NpcType.Task)
            {
                return DoTaskInterative(npc);
            }
            else if(npc.Type == NpcDefine.NpcType.Functional)
            {
                return DoFunctionInterative(npc);
            }
            else
            { return false; }
        }

        public bool DoTaskInterative(NpcDefine npc)
        {
            MessageBox.Show("弹出了" + npc.Name);
            return true;
        }

        public bool DoFunctionInterative(NpcDefine npc)
        {
            if(npc.Type != NpcDefine.NpcType.Functional) { return false; }
            if (!eventMap.ContainsKey(npc.Function)) {  return false; }
            return eventMap[npc.Function](npc);
        }
    }
}
