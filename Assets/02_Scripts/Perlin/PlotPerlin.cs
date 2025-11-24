using UnityEngine;

public class PlotPerlin : MonoBehaviour
{
    [Range(1, 8)]
    public int octaves = 2;

    [Header("Offset")]
    [Range(0,1000)]
    public int xOffset = 0;
    [Range(0,1000)]
    public int yOffset = 0;

    [Header("Density")]
    [Range(0.001f, 0.01f)]
    public float xScale = 0;
    [Range(0.001f, 0.01f)]
    public float yScale = 0;

    [Header("Color Cutoff")]
    [Range(0.0f, 1.0f)]
    public float greenCutoff = 0;
    [Range(0.0f, 1.0f)]
    public float blueCutoff = 0;
    [Range(0.0f, 1.0f)]
    public float yelloCutoff = 0;

    /// <summary>
    /// 에디터에서만 호출되는 함수로 값이 변경될 때마다 호출
    /// </summary>
    private void OnValidate()
    {
        Texture2D texture = new Texture2D(1024, 1024);
        GetComponent<Renderer>().sharedMaterial.mainTexture = texture;

        float perlin;
        Color color;

        for(int y=0; y<texture.height; y++)
        {
            for(int x=0; x<texture.width; x++)
            {
                // 유니티에서 PerlinNoise를 제공
                // 0~1 사이 값 제공
                // 2개의 매개변수는 좌표. 이 좌표의 노이즈를 조회하는 것.
                perlin = FBM((x+xOffset) * xScale, (y+yOffset) * yScale, octaves);

                if (perlin < greenCutoff)
                    color = Color.green;
                else if(perlin < blueCutoff)
                    color = Color.blue;
                else 
                    color = Color.yellow;

                texture.SetPixel(x, y, color);  
            }
        }
        texture.Apply();
    }

    public float FBM(float _x, float _y, int _octaves)
    {
        float total = 0;
        float frequency = 1;
        for(int i=0; i< _octaves; i++)
        {
            total += Mathf.PerlinNoise(_x * frequency, _y * frequency);
            frequency *= 2;
        }
        return total / (float)octaves;
    }
}
