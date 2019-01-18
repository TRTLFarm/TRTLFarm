﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Services
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}
