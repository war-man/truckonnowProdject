﻿using ApiMobaileServise.Servise;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMobaileServise.BackgraundService.Queue
{
    public class VideoSave : IJob
    {
        private ManagerMobileApi managerMobileApi = null;
        public static List<string> queues = new List<string>();
        public static int countQueues = 0;
        public static bool isWork = false;

        public void Execute()
        {
            managerMobileApi = new ManagerMobileApi();
            Task.Run(() => QWork());
        }

        private async void QWork()
        {
            if (queues.Count != 0 && !isWork)
            {
                isWork = true;
                int tmpCount = queues.Count > 5000 ? queues.Count - (countQueues - 5000) : queues.Count;
                for (int i = 0; i < tmpCount; i++)
                {
                    if (queues[i].Split("&,&")[0] == "SaveRecount")
                    {
                        await managerMobileApi.SaveRecount(queues[i].Split("&,&")[1], Convert.ToInt32(queues[i].Split("&,&")[2]), queues[i].Split("&,&")[3]);
                    }
                    countQueues--;
                }
                queues.RemoveRange(0, tmpCount);
                isWork = false;
            }
        }
    }
}
