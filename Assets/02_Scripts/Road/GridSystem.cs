using UnityEngine;
using System.Linq;

public class GridSystem : MonoBehaviour
{
    public GameObject straight;
    public GameObject crossroad;
    public GameObject corner;
    public int width = 100;
    public int depth = 100;


    void Start()
    {
        for(int z= 0; z< depth; z += 10) // model size = 10
        {
            for(int x = 0; x<width; x += 10)
            {
                Vector3 position = new Vector3(x,0,z);
                GameObject r = Instantiate(crossroad, position, Quaternion.identity);
            }
        }  
    }
}
