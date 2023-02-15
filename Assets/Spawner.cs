using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Cube;
    void Start()
    {
        InvokeRepeating(methodName:"Spawn", time:0, repeatRate:5f);
    }

    private void Spawn()
    {
        Instantiate(Cube);
        Cube.transform.position = new Vector3(Random.Range(-3.5f, 3.5f), 1, 300);
    }
}
