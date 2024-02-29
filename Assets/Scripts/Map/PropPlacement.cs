using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropPlacement : MonoBehaviour
{
    public GameObject[] randomProps;

    public int maxQuantity = 5;
    public int minQuantity = 0;


    Vector3 RandomLocationInsideBlock()
    {
        return new Vector3(Random.Range(-4.5f, 4.5f), 0, Random.Range(-4.5f, 4.5f));
    }
    void Start()
    {
        int quant = Random.Range(minQuantity, maxQuantity);

        if(quant>0)
        for(int i = 0;i< quant;i++)
            {
               GameObject newGo = Instantiate(randomProps[Random.Range(0, randomProps.Length)], transform);
               newGo.transform.localPosition = RandomLocationInsideBlock();
                Quaternion rotation = newGo.transform.rotation;
                rotation.eulerAngles += new Vector3(0, Random.Range(0,360), 0);
                newGo.transform.rotation = rotation;
            }
    }

}
