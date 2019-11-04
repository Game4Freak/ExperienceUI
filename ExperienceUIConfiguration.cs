using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game4Freak.ExperienceUI
{
    public class ExperienceUIConfiguration : IRocketPluginConfiguration
    {
        public ushort UIID;
        public short key;

        public void LoadDefaults()
        {
            UIID = 1000;
            key = 304;
        }
    }
}
