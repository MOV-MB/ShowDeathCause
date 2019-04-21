using System;
using BepInEx;
using RoR2;
using ComboSkill = On.RoR2.ComboSkill;

namespace ShowDeathCause
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.MyCompanyName.ShowDeathCause", "ShowDeathCause", "1.0.0")]
    public class ShowDeathCause : BaseUnityPlugin
    {
        public void Awake()
        {
            On.RoR2.GlobalEventManager.OnPlayerCharacterDeath += GlobalEventManager_OnPlayerCharacterDeath;
        }

        private void GlobalEventManager_OnPlayerCharacterDeath(On.RoR2.GlobalEventManager.orig_OnPlayerCharacterDeath orig, GlobalEventManager self, DamageInfo damageInfo, UnityEngine.GameObject victim, NetworkUser victimNetworkUser)
        {
            orig(self, damageInfo, victim, victimNetworkUser);
            CharacterBody component = victim.GetComponent<CharacterBody>();    
            NetworkUser networkUser = Util.LookUpBodyNetworkUser(component);  

            string deathMessage = $"Killed by <color=#FF8000>{damageInfo.attacker.GetComponent<CharacterBody>().GetDisplayName()}</color> with {damageInfo.inflictor.GetComponent<GenericSkill>().skillName}"; 

            if (!networkUser) return;
            Chat.SendBroadcastChat(new Chat.SimpleChatMessage
            {
              
                baseToken = deathMessage


            });

        }

    }
}
