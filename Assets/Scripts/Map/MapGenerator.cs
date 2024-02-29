using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Map
{
    public class MapGenerator : MonoBehaviour
    {
        public int mapSize = 10;
        public float slotSize = 10;
        public GameObject[] randomBlocks;

        GameObject GetRandBlock()
        {
            return randomBlocks[Random.Range(0, randomBlocks.Length)]; 
        }

        private void Start()
        {
            for(int i=0;i < mapSize;i++)
                for(int j=0;j< mapSize;j++) 
                {
                   Instantiate(GetRandBlock(), new Vector3(i * slotSize, 0, j * slotSize),Quaternion.identity,transform);
                }


        }

    }
}