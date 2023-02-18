using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    int itemSpace = 15;
    int itemCountInMap = 5;
    enum TrackPos { Left = -1, Center =0 , Right =1 };
    enum CoinsStyle {Line1, line2 };
    public float laneOffset = 4.8f;
    int coinsCountInItem = 10;
    float coinsHeight = 0.5f;

    public GameObject Obstacle1;
    public GameObject Obstacle2;
    public GameObject Obstacle3;
    public GameObject Obstacle4;
    public GameObject Obstacle5;
    public GameObject Obstacle6;
    public GameObject Obstacle7;
    public GameObject Obstacle8;
    public GameObject Obstacle9;
    public GameObject Coin;

    public List<GameObject> maps = new List<GameObject>();
    static public ObstaclesGenerator instance;

    struct MapItem
    {
        public void SetValues(GameObject obstacle, TrackPos trackPos, CoinsStyle coinStyle)
        {
            this.obscacle = obstacle; this.trackPos = trackPos; this.coinStyle = coinStyle;
        }
        public GameObject obscacle;
        public TrackPos trackPos;
        public CoinsStyle coinStyle;
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        maps.Add(MakeMap1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    GameObject MakeMap1()
    {
        GameObject result = new GameObject("Map1");
        result.transform.SetParent(transform);
        MapItem item = new MapItem();
        for(int i = 0; i < itemCountInMap; i++)
        {
            GameObject obstacle = null;
            TrackPos trackPos = TrackPos.Center;
            CoinsStyle coinStyle = CoinsStyle.Line1;

            if (i == 2) { trackPos = TrackPos.Left; obstacle = Obstacle1; }
            else if (i == 3) { trackPos = TrackPos.Right; obstacle = Obstacle2; }
            else if (i == 4) { trackPos = TrackPos.Right; obstacle = Obstacle3; }

            Vector3 obstaclePos = new Vector3(laneOffset, 0, i * itemSpace);
            CreateCoins(item.coinStyle, obstaclePos, result);
            if (obstacle !=null)
            {
                GameObject go = Instantiate(obstacle, obstaclePos, Quaternion.identity);
                go.transform.SetParent(result.transform);
            }
        }
        return result;
    }
    void CreateCoins(CoinsStyle style, Vector3 pos, GameObject parentObject)
    {
        Vector3 coinPos = Vector3.zero;
        if (style == CoinsStyle.Line1)
        {
            for (int i = -coinsCountInItem/2; i < coinsCountInItem / 2; i++)
            {
                coinPos.y = coinsHeight;
                coinPos.z = i * ((float)itemSpace / coinsCountInItem);
                GameObject go = Instantiate(Coin, coinPos + pos, Quaternion.identity);
                go.transform.SetParent(parentObject.transform);

            }
        }
        
    }
}
