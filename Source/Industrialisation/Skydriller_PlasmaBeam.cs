using UnityEngine;
using Verse;

namespace Industrialisation;

[StaticConstructorOnStartup]
public class Skydriller_PlasmaBeam(Map map) : WeatherEvent(map)
{
    private static readonly Material PlasmaBeamMat = MaterialPool.MatFrom("Ind/SkyDriller/PlasmaBeam");

    private readonly int duration = 16;

    private int age;

    private Mesh boltMesh;
    private IntVec3 strikeLoc = IntVec3.Invalid;

    public Skydriller_PlasmaBeam(Map map, IntVec3 forcedStrikeLoc)
        : this(map)
    {
        strikeLoc = forcedStrikeLoc;
    }

    public override bool Expired => age > duration;

    private float PBBrightness
    {
        get
        {
            if (age <= 2)
            {
                return age / 2f;
            }

            return (float)(1.0 - (age / (double)duration));
        }
    }

    public override void WeatherEventTick()
    {
        age++;
    }

    public override void FireEvent()
    {
        if (!strikeLoc.IsValid)
        {
            strikeLoc = CellFinderLoose.RandomCellWith(sq => sq.Standable(map) && !sq.Roofed(map), map);
        }

        boltMesh = Skydriller_PLasmaBeam_MeshMaker.NewBoltMesh();
    }

    public override void WeatherEventDraw()
    {
        Graphics.DrawMesh(boltMesh, strikeLoc.ToVector3ShiftedWithAltitude(AltitudeLayer.WorldClipper),
            Quaternion.identity, FadedMaterialPool.FadedVersionOf(PlasmaBeamMat, PBBrightness), 0);
    }
}