using RimWorld;
using Verse;

namespace Industrialisation;

internal class Building_SkydrillerCallmaker_Calling : Building
{
    public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
    {
        var position = Position;
        var map = Map;
        base.Destroy(mode);
        GenSpawn.Spawn(ThingDef.Named("Ind_SkydrillerCallmaker_Drilling"), position, map);
        Messages.Message("Ind_SkyDriller_StartDrilling".Translate(), MessageTypeDefOf.ThreatSmall);
    }
}