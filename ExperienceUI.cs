using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace Game4Freak.ExperienceUI
{
    public class ExperienceUI : RocketPlugin<ExperienceUIConfiguration>
    {
        public static ExperienceUI Instance;
        public const string VERSION = "1.0.0";
        private IRocketPermissionsProvider _defaultPermissionsProvider;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("ExperienceUI v" + VERSION);

            U.Events.OnPlayerConnected += onPlayerConnected;
            UnturnedPlayerEvents.OnPlayerUpdateExperience += onExperienceUpdated;
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= onPlayerConnected;
            UnturnedPlayerEvents.OnPlayerUpdateExperience -= onExperienceUpdated;
        }

        public override TranslationList DefaultTranslations =>
            new TranslationList()
            {
                {"experience_text", "<color=white>{0} exp</color>"},
            };

        private void onPlayerConnected(UnturnedPlayer player)
        {
            EffectManager.sendUIEffect(Configuration.Instance.UIID, Configuration.Instance.key, player.CSteamID, true, Translate("experience_text", player.Experience.ToString()));
        }

        private void onExperienceUpdated(UnturnedPlayer player, uint experience)
        {
            EffectManager.sendUIEffect(Configuration.Instance.UIID, Configuration.Instance.key, player.CSteamID, true, player.Experience.ToString());
        }
    }
}