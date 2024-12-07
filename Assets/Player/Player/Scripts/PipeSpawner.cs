using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;
     private float timer;
    [SerializeField] private float maxTimer;

    void Start()
    {
        timer = maxTime;
       

    }
    private void Update()
    {
        if(timer > maxTime)
        {
            SpawnPipes();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnPipes()
    {
        Vector3 spawmPos = transform.position + new Vector3(0,Random.Range(-heightRange, heightRange)); 
        GameObject pipe = Instantiate(_pipe , spawmPos , Quaternion.identity);
        Destroy(pipe, 10f);
    }


}
