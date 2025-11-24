using UnityEngine;

public class CreateCity : MonoBehaviour
{
    int width = 100;
    int depth = 100;

    public Material residential;
    public Material commercial;
    public Material industrial;

    public GameObject gos;
    private void Start()
    {
        //Texture2D texture = new Texture2D(1024, 1024);
        //gos.GetComponent<Renderer>().sharedMaterial.mainTexture = texture;
        //for(int i=0; i<1024; i++)
        //{
        //    for(int k=0; k<1024; k++)
        //    {
        //        texture.SetPixel(k,i,Color.white);
        //    }
        //}
        //texture.Apply();

        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.position = new Vector3(x,0,z);

                Renderer rend = go.GetComponent<Renderer>();    
                rend.material = residential;

                float perlin = MeshUtils.PerlinNoise(x * 0.003f, z * 0.003f, 3);

                int h = 1;
                if(perlin < 0.4)
                {
                    h = 1;
                }
                else if(perlin < 0.6f)
                {
                    h = 2;
                }

                go.transform.localScale = new Vector3(1, h, 1);
                go.transform.Translate(0, h/2.0f ,0);    
            }
        }
    }
}
