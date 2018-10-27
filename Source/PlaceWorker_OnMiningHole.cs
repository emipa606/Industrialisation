// Decompiled with JetBrains decompiler
// Type: RimWorld.PlaceWorker_OnSteamGeyser
// Assembly: Assembly-CSharp, Version=0.8.5476.23593, Culture=neutral, PublicKeyToken=null
// MVID: 50EAA954-ECB6-4D9B-9A07-53C8F3E535D9
// Assembly location: E:\Downloads\RimWorld671Win\RimWorld671Win_Data\Managed\Assembly-CSharp.dll

using Verse;

namespace Industrialisation
{
    public class PlaceWorker_OnMiningHole : PlaceWorker
    {
        //public static ThingDef MiningHole = ThingDef.Named("MiningHole");
        
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null)
        {
            Thing thing = map.thingGrid.ThingAt(loc, ThingDef.Named("Ind_MiningHole"));
            if (thing == null || thing.Position != loc)
            {
                return "Ind_MustPlaceOnMiningHole".Translate();
            }
            return true;
        }
    }

    public class PlaceWorker_OnConcreteSeal : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null)
        {
            Thing seal = map.thingGrid.ThingAt(loc, ThingDef.Named("Ind_ConcreteSeal"));
            Thing hole = map.thingGrid.ThingAt(loc, ThingDef.Named("Ind_MiningHole"));
            if (hole == null || hole.Position != loc)
            {
                return "Ind_MustPlaceOnMiningHole".Translate();
            }

            if (seal == null || seal.Position != loc)
            {
                return "Ind_MustPlaceOnConcreteSeal".Translate();
            }
            return true;
        }
        public override void PostPlace(Map map, BuildableDef def, IntVec3 loc, Rot4 rot)
        {
            Thing reclaim = map.thingGrid.ThingAt(loc, ThingDef.Named("Ind_ReclaimSeal"));

            reclaim.Destroy(DestroyMode.Vanish);

            Thing seal = map.thingGrid.ThingAt(loc, ThingDef.Named("Ind_ConcreteSeal"));

            if (seal != null)
            {
                seal.Destroy(DestroyMode.Vanish);

                Thing hole = map.thingGrid.ThingAt(loc, ThingDef.Named("Ind_MiningHole"));

                if (hole != null)
                {
                    hole.Destroy(DestroyMode.Vanish);                    
                }
            }
        }
    }
}