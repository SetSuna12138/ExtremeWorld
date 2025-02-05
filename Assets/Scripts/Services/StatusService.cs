﻿using Models;
using Network;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Services
{
    class StatusService : Singleton<StatusService>, IDisposable
    {
        public delegate bool StatusNotifyHandler(NStatus status);

        Dictionary<StatusType, StatusNotifyHandler> eventMap = new Dictionary<StatusType, StatusNotifyHandler>();

        public void Init()
        {

        }

        public void RigisterStatusNofity(StatusType function, StatusNotifyHandler action)
        {
            if (!eventMap.ContainsKey(function))
            {
                eventMap[function] = action;
            }
            else
                eventMap[function] += action;
        }

        public void Dispose()
        {
            MessageDistributer.Instance.Unsubscribe<StatusNotify>(this.OnStatusNotify);
        }

        public void OnStatusNotify(object sender, StatusNotify notify)
        {
            foreach (NStatus status in notify.Status)
            {
                Notity(status);
            }
        }

        private void Notity(NStatus status)
        {
            if(status.Type == StatusType.Money) 
            {
                if (status.Action == StatusAction.Add)
                    User.Instance.AddGold(status.Value);
                else if(status.Action == StatusAction.Delete)
                    User.Instance.AddGold(-status.Value);

            }

            StatusNotifyHandler handler;
            if(eventMap.TryGetValue(status.Type, out handler))
            {
                handler(status);
            }
        }

        

    }
}
