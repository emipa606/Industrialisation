using RimWorld;
using Verse;

namespace Industrialisation;

internal class CompUseEffect_ActiveSkyDrillerCallMaker : CompUseEffect
{
    public override void DoEffect(Pawn usedBy)
    {
        base.DoEffect(usedBy);
        GenSpawn.Spawn(ThingDef.Named("Ind_SkydrillerCallmaker_Calling"), parent.Position, parent.Map);
        Messages.Message("Ind_SkyDriller_Calling".Translate(), MessageTypeDefOf.PositiveEvent);
    }
}