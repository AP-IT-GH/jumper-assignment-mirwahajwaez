using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentJumper : MonoBehaviour
{
    //Toegevoegd en aangepast
    public GameObject BadObstaclePrefab;
    public GameObject GoodObstaclePrefab;

    public GameObject Obstacles;
    public bool canSpawnObstacles = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Obstacles = transform.Find("Obstacles").gameObject;
        Debug.Log("start spwn");
        
        StartCoroutine(SpawnObstacleContinuously());

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObstacleContinuously()
    {
        while (true)
        {
            float result = Random.Range(0, 2);
            Debug.Log(result);
            float r = Random.Range(2f, 5.0f);
            yield return new WaitForSeconds(r);
            if (canSpawnObstacles)

                //Toegevoegd
                if (result == 0)
                    SpawnBadObstacle();
                else
                    SpawnGoodObstacle();
        }
    }

    //Spawn every X seconds

    //Toegevoegd en aangepast
    public void SpawnBadObstacle()
    {
        GameObject newBadObstacle = Instantiate(BadObstaclePrefab.gameObject);

        newBadObstacle.transform.SetParent(Obstacles.transform);
        // float rx = Random.Range(-4f, 4);
        // float rz = Random.Range(-4f, 2);
        newBadObstacle.transform.localPosition = new Vector3(-8, 0.5f, 0);
    }

    public void SpawnGoodObstacle()
    {
        GameObject newGoodObstacle = Instantiate(GoodObstaclePrefab.gameObject);

        newGoodObstacle.transform.SetParent(Obstacles.transform);
        // float rx = Random.Range(-4f, 4);
        // float rz = Random.Range(-4f, 2);
        newGoodObstacle.transform.localPosition = new Vector3(-8, 0.5f, 0);
    }

    public void ClearEnvironment()
    {        
        foreach (Transform anyObstacle in Obstacles.transform)
        {
            GameObject.Destroy(anyObstacle.gameObject);
        }
        canSpawnObstacles = true;
    }
}
