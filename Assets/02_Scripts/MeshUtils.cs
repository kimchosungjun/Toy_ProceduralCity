using UnityEngine;

public static class MeshUtils 
{
    public static float PerlinNoise(float _x, float _y, int _octaves)
    {
        float total = 0;
        float frequency = 1;
        for (int i = 0; i < _octaves; i++)
        {
            total += Mathf.PerlinNoise(_x * frequency, _y * frequency);
            frequency *= 2;
        }
        return total / (float)_octaves;
    }

    public static void GenerateVoronoi()
    {

    }
}
