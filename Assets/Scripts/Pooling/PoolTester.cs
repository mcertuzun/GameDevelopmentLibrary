using Assets.Library.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolTester : MonoBehaviour
{
    [SerializeField] Transform SpawnLocation;
    [SerializeField] PoolInfoWithPool pool;
    [SerializeField] float force;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = pool.Fetch();
            go.transform.position = transform.position;
            go.SetActive(true);
            go.GetComponent<Rigidbody>().AddForce(transform.up * force);
        }
    }
}
