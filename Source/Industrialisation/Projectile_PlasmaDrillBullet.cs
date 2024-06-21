using Verse;

namespace Industrialisation;

public class Projectile_PlasmaDrillBullet : Projectile
{
    protected override void Impact(Thing hitThing, bool blockedByShield = false)
    {
        base.Impact(hitThing, blockedByShield);
        GenSpawn.Spawn(ThingDef.Named("Ind_PlasmaDrillDeployed"), Position, Find.CurrentMap);
    }
}