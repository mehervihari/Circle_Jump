using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject LineFab;
    public float Spawnrate = 1f;
    public float minHeight = -4f;
    public float maxHeight = 4f;

    // Update is called once per frame
    /*void Update()
    {
        Spawn();
    }*/

    private void OnEnable()
    {
        InvokeRepeating("Spawn", Spawnrate, Spawnrate);
    }

    private void OnDisable()
    {
        CancelInvoke("Spawn");
    }

    private void Spawn()
    {
        //GameObject blackLine = Instantiate(LineFab, transform.position, Quaternion.identity);
        LineFab.transform.position += new Vector3(transform.position.x, Random.Range(maxHeight, minHeight), transform.position.z);
    }
}
