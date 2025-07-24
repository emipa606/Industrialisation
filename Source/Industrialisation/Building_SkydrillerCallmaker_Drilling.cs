using RimWorld;
using Verse;
using Verse.Sound;

namespace Industrialisation;

internal class Building_SkydrillerCallmaker_Drilling : Building
{
    private static readonly SoundDef plasmaDrillSound = SoundDef.Named("Ind_PlasmaDrill");

    private static readonly SoundDef plasmaDrillFireSound = SoundDef.Named("Ind_PlasmaDrillFire");

    private static readonly float plasmaArmorPenetration = 0.02f;

    private static readonly bool plasmaApplyDamageToExplosionCellsNeighbors = true;

    private static readonly float plasmaChanceToStartFire = 0.1f;

    private static readonly bool plasmaDamageFalloff = false;

    private static readonly int plasmaPreExplosionSpawnThingCount = 1;

    private static readonly float plasmaPreExplosionSpawnChance = 0f;

    private static readonly int plasmaPostExplosionSpawnThingCount = 1;

    private static readonly float plasmaPostExplosionSpawnChance = 0f;

    private readonly int plasmaDamage = 10;

    private int explosionTick = 4;
    private int plasmaTick = 4;

    protected override void Tick()
    {
        base.Tick();
        plasmaTick--;
        explosionTick--;
        if (plasmaTick == 0)
        {
            Map.weatherManager.eventHandler.AddEvent(new Skydriller_PlasmaBeam(Map, Position));
            explosionTick = 4;
        }

        if (explosionTick != 0)
        {
            return;
        }

        GenExplosion.DoExplosion(Position, Map, 1.5f, DamageDefOf.Flame, null, plasmaDamage, plasmaArmorPenetration,
            plasmaDrillSound, null, null, null, null, plasmaPostExplosionSpawnChance,
            plasmaPostExplosionSpawnThingCount, GasType.BlindSmoke, null, 0, plasmaApplyDamageToExplosionCellsNeighbors,
            null, plasmaPreExplosionSpawnChance, plasmaPreExplosionSpawnThingCount, plasmaChanceToStartFire,
            plasmaDamageFalloff);
        plasmaTick = 4;
    }

    public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
    {
        var position = Position;
        var map = Map;
        base.Destroy(mode);
        plasmaDrillFireSound.PlayOneShot(new TargetInfo(position, map));
        GenSpawn.Spawn(ThingDef.Named("Ind_MiningHole"), position, map);
        Messages.Message("Ind_SkyDriller_Completed".Translate(), MessageTypeDefOf.PositiveEvent);
    }
}