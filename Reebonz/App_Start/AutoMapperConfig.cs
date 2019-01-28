using AutoMapper;
using Reebonz.MapProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reebonz.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Config()
        {

            Mapper.Initialize(x =>
            {
                x.AddProfile<OrderProfile>();
            });
        }
    }
}