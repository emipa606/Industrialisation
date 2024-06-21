using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.Noise;

namespace Industrialisation;

public static class Skydriller_PLasmaBeam_MeshMaker
{
    private const float LightningHeight = 200f;

    private const float LightningRootXVar = 50f;

    private const float VertexInterval = 0.25f;

    private const float MeshWidth = 2f;

    private const float UVIntervalY = 0.04f;

    private const float PerturbAmp = 0f;

    private const float PerturbFreq = 0.007f;
    private static Mesh laserBeamMesh;

    private static List<Vector2> verts2D;

    private static Vector2 lightningTop;

    public static Mesh NewBoltMesh()
    {
        if (laserBeamMesh != null)
        {
            return laserBeamMesh;
        }

        lightningTop = new Vector2(PerturbAmp, LightningHeight);
        MakeVerticesBase();
        PeturbVerticesRandomly();
        DoubleVertices();
        laserBeamMesh = MeshFromVerts();

        return laserBeamMesh;
    }

    private static void MakeVerticesBase()
    {
        var num = (int)Math.Ceiling((Vector2.zero - lightningTop).magnitude / VertexInterval);
        var vector = lightningTop / num;
        verts2D = [];
        var zero = Vector2.zero;
        for (var i = 0; i < num; i++)
        {
            verts2D.Add(zero);
            zero += vector;
        }
    }

    private static void PeturbVerticesRandomly()
    {
        var perlin = new Perlin(0.007000000216066837, 2.0, 0.5, 6, Rand.Range(0, int.MaxValue), QualityMode.High);
        var list = verts2D.ListFullCopy();
        verts2D.Clear();
        var num = 0;
        foreach (var item2 in list)
        {
            var num2 = 0f * (float)perlin.GetValue(num, 0.0, 0.0);
            var item = item2 + (num2 * Vector2.right);
            verts2D.Add(item);
            num++;
        }
    }

    private static void DoubleVertices()
    {
        var list = verts2D.ListFullCopy();
        var vector2 = default(Vector2);
        verts2D.Clear();
        for (var i = 0; i < list.Count; i++)
        {
            if (i <= list.Count - 2)
            {
                var vector = Quaternion.AngleAxis(90f, Vector3.up) * (list[i] - list[i + 1]);
                vector2 = new Vector2(vector.y, vector.z);
                vector2.Normalize();
            }

            var item = list[i] - (1f * vector2);
            var item2 = list[i] + (1f * vector2);
            verts2D.Add(item);
            verts2D.Add(item2);
        }
    }

    private static Mesh MeshFromVerts()
    {
        var array = new Vector3[verts2D.Count];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = new Vector3(verts2D[i].x, 0f, verts2D[i].y);
        }

        var num = 0f;
        var array2 = new Vector2[verts2D.Count];
        for (var j = 0; j < verts2D.Count; j += 2)
        {
            array2[j] = new Vector2(0f, num);
            array2[j + 1] = new Vector2(1f, num);
            num += UVIntervalY;
        }

        var array3 = new int[verts2D.Count * 3];
        for (var k = 0; k < verts2D.Count - 2; k += 2)
        {
            var num2 = k * 3;
            array3[num2] = k;
            array3[num2 + 1] = k + 1;
            array3[num2 + 2] = k + 2;
            array3[num2 + 3] = k + 2;
            array3[num2 + 4] = k + 1;
            array3[num2 + 5] = k + 3;
        }

        return new Mesh
        {
            vertices = array,
            uv = array2,
            triangles = array3
        };
    }
}