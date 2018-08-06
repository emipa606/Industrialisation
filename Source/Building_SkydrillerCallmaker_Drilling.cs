using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using Verse.Sound;

namespace Industrialisation
{
    class Building_SkydrillerCallmaker_Drilling : Building
    {
        private int plasmaTick = 4;
        private int explosionTick = 4;
        private int plasmaDamage = 1;
        private static readonly SoundDef plasmaDrillSound = SoundDef.Named("Ind_PlasmaDrill");        
        private static readonly SoundDef plasmaDrillFireSound = SoundDef.Named("Ind_PlasmaDrillFire");
        private static readonly float plasmaArmorPenetration = 0.0f;
        private static bool plasmaApplyDamageToExplosionCellsNeighbors = false;
        private static float plasmaChanceToStartFire = 0.1f;
        private static bool plasmaDamageFalloff = false;
        private static int plasmaPreExplosionSpawnThingCount = 1;
        private static float plasmaExplosionRadius = 1.5f;
        private static float plasmaPreExplosionSpawnChance = 0;
        private static int plasmaPostExplosionSpawnThingCount = 1;
        private static float plasmaPostExplosionSpawnChance = 0;

        public override void Tick()
        {
            base.Tick();
            this.plasmaTick--;
            this.explosionTick--;

            if (this.plasmaTick == 0)
            {
                base.Map.weatherManager.eventHandler.AddEvent(new Skydriller_PlasmaBeam(base.Map, this.Position));
                this.explosionTick = 4;
            }

            if (this.explosionTick == 0)
            {
                MoteMaker.MakeStaticMote(base.Position, base.Map, ThingDefOf.Mote_ShotFlash, 9.0f);
                GenExplosion.DoExplosion(base.Position, base.Map, plasmaExplosionRadius, DamageDefOf.Flame, (Thing)null, plasmaDamage, 
                    plasmaArmorPenetration, plasmaDrillSound, (ThingDef)null, (ThingDef)null, (Thing)null, (ThingDef)null, 
                    plasmaPostExplosionSpawnChance, plasmaPostExplosionSpawnThingCount,
                    plasmaApplyDamageToExplosionCellsNeighbors, (ThingDef)null, plasmaPreExplosionSpawnChance, 
                    plasmaPreExplosionSpawnThingCount, plasmaChanceToStartFire, plasmaDamageFalloff);
                this.plasmaTick = 4;
            }
        }

        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
        {
            var position = this.Position;
            var map = base.Map;
            base.Destroy(mode);
            SoundStarter.PlayOneShot(plasmaDrillFireSound, new TargetInfo(position, map, false));
            GenSpawn.Spawn(ThingDef.Named("Ind_MiningHole"), position, map);
            Messages.Message("Ind_SkyDriller_Completed".Translate(), MessageTypeDefOf.PositiveEvent);
        }
    }
    class Building_SkydrillerCallmaker_OrbitalStrike : OrbitalStrike
    {
        private int plasmaTick = 4;
        private int explosionTick = 4;
        private int plasmaDamage = 1;
        private static readonly SoundDef plasmaDrillSound = SoundDef.Named("Ind_PlasmaDrill");        
        private static readonly SoundDef plasmaDrillFireSound = SoundDef.Named("Ind_PlasmaDrillFire");
        private static readonly float plasmaArmorPenetration = 0.0f;
        private static bool plasmaApplyDamageToExplosionCellsNeighbors = false;
        private static float plasmaChanceToStartFire = 0.1f;
        private static bool plasmaDamageFalloff = false;
        private static int plasmaPreExplosionSpawnThingCount = 1;
        private static float plasmaExplosionRadius = 1.5f;
        private static float plasmaPreExplosionSpawnChance = 0;
        private static int plasmaPostExplosionSpawnThingCount = 1;
        private static float plasmaPostExplosionSpawnChance = 0;

        public override void Tick()
        {
            base.Tick();
            this.plasmaTick--;
            this.explosionTick--;

            if (this.plasmaTick == 0)
            {
                base.Map.weatherManager.eventHandler.AddEvent(new Skydriller_PlasmaBeam(base.Map, this.Position));
                this.explosionTick = 4;
            }

            if (this.explosionTick == 0)
            {
                MoteMaker.MakeStaticMote(base.Position, base.Map, ThingDefOf.Mote_ShotFlash, 9.0f);
                GenExplosion.DoExplosion(base.Position, base.Map, plasmaExplosionRadius, DamageDefOf.Flame, (Thing)null, plasmaDamage, 
                    plasmaArmorPenetration, plasmaDrillSound, (ThingDef)null, (ThingDef)null, (Thing)null, (ThingDef)null, 
                    plasmaPostExplosionSpawnChance, plasmaPostExplosionSpawnThingCount,
                    plasmaApplyDamageToExplosionCellsNeighbors, (ThingDef)null, plasmaPreExplosionSpawnChance, 
                    plasmaPreExplosionSpawnThingCount, plasmaChanceToStartFire, plasmaDamageFalloff);
                this.plasmaTick = 4;
            }
        }

        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
        {
            var position = this.Position;
            var map = base.Map;
            base.Destroy(mode);
            SoundStarter.PlayOneShot(plasmaDrillFireSound, new TargetInfo(position, map, false));
            GenSpawn.Spawn(ThingDef.Named("Ind_MiningHole"), position, map);
            Messages.Message("Ind_SkyDriller_Completed".Translate(), MessageTypeDefOf.PositiveEvent);
        }
    }
}
