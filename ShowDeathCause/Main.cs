using System;
using BepInEx;
using RoR2;

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
            throw new NotImplementedException();
        }
    }
}
