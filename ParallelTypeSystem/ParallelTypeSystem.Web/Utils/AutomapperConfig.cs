using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParallelTypeSystem.Web.Utils
{
    public class AutomapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.Initialize(config =>
            {
            });
        }
    }
}