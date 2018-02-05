using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject CubePrefab;
    List<data> ValueList;
    List<GameObject> CubeList;

    struct data
    {
        public int score;
        public int value;
    }

	// Use this for initialization
	void Start () {
        ValueList = new List<data>();
		
	}
	
	// Update is called once per frame
	void Update () {
        data nData = new data();
        int newValue = Mathf.RoundToInt( RandomFromDistribution.RandomNormalDistribution(1000.0f, 1.0f));
        bool valueFound = false;

        foreach (data cData in ValueList)
        {
            if(cData.value == newValue)
            {
                nData = cData;
                valueFound = true;

            }

        }

        if(valueFound)
        {
            ValueList.Remove(nData);
            nData.score += 1;
            ValueList.Add(nData);
        }
        else
        {
            nData.value = newValue;
            nData.score = 1;
            ValueList.Add(nData);
        }

        foreach (data cData in ValueList)
        {
            GameObject nGO = GameObject.Instantiate(CubePrefab);
            nGO.transform.position = new Vector3(cData.value * 3.0f, cData.score * 1, 0.0f);

        }
    }
}
