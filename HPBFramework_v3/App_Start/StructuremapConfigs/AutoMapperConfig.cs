using AutoMapper;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


internal class AutoMapperConfig
{
    public static void Register(IContainer container)
    {
        var profiles = container.GetInstance<List<Profile>>();
        Mapper.Initialize(cfg =>
        {
            foreach (var profile in profiles)
                cfg.AddProfile(profile);
        });

    }
}