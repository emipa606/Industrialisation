using RimWorld;
using Verse;

namespace Industrialisation;

public class Building_NuclearPowerPlant : Building
{
    private int Burnticks = 40;

    public override void Tick()
    {
        base.Tick();
        if (--Burnticks != 0)
        {
            return;
        }

        FleckMaker.ThrowSmoke(Position.ToVector3Shifted(), Map, 3f);
        FleckMaker.ThrowSmoke(Position.ToVector3Shifted(), Map, 4f);
        Burnticks = 40;
    }
}