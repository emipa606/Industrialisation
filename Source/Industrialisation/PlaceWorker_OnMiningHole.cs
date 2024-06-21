using Verse;

namespace Industrialisation;

public class PlaceWorker_OnMiningHole : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        var thing2 = map.thingGrid.ThingAt(loc, ThingDef.Named("Ind_MiningHole"));
        if (thing2 == null || thing2.Position != loc)
        {
            return "Ind_MustPlaceOnMiningHole".Translate();
        }

        return true;
    }
}