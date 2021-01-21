﻿using System.IO;
using System.Reflection;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Utilities;
using SaberFactory.Configuration;
using SaberFactory.Helpers;
using SaberFactory.Installers;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace SaberFactory
{

    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        [Init]
        public async void Init(IPALogger logger, Config conf, Zenjector zenjector)
        {
            Assembly.Load(await Readers.ReadResourceAsync("SaberFactory.Resources.CustomSaberComponents.dll"));

            var saberFactoryDir = new DirectoryInfo(UnityGame.UserDataPath).CreateSubdirectory("Saber Factory");

            zenjector.OnApp<AppInstaller>().WithParameters(logger, conf, saberFactoryDir);
            zenjector.OnMenu<Installers.MenuInstaller>();
            zenjector.OnGame<GameInstaller>();
        }

        [OnStart]
        public void OnApplicationStart()
        {
        }

        [OnExit]
        public void OnApplicationQuit()
        {
        }
    }
}
