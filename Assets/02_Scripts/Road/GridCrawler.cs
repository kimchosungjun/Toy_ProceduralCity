using UnityEngine;

public class GridCrawler : MonoBehaviour
{
    public GameObject crawler;
    int width = 5000;
    int depth = 5000;
    Vector3Int crawlerPos;

    void Start()
    {
            
    }

    void Update()
    {
        int dx = Random.Range(-1, 2);
        int dz = Random.Range(-1, 2);
        if(Random.Range(0,2) == 0)
        {
            crawlerPos += new Vector3Int(0, 0, dz * 20);
        }
        else
        {
            crawlerPos += new Vector3Int(dx * 20, 0, 0);
        }
        crawler.transform.position = crawlerPos;    
    }
}
