using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject LineFab;
    public Transform currentLine;
    [SerializeField]
    private float Spawnrate;
    [SerializeField]
    private float Spawntime;
    public float minHeight = -4f;
    public float maxHeight = 4f;
    private float nextLineDirection;
    public GameObject[] prefabs = new GameObject[4];

    // Update is called once per frame
    /*void Update()
    {
        Spawn();
    }*/

    private void OnEnable()
    {
        InvokeRepeating("Spawn", Spawntime, Spawnrate);
    }

    private void OnDisable()
    {
        CancelInvoke("Spawn");
    }

    private void Spawn()
    {
        //nextLineDirection = Random.Range(minHeight, maxHeight);
        //if(nextLineDirection == 0)
        GameObject tobeSpawned = prefabs[Random.Range(0, prefabs.Length)];

        float radians = (MathF.PI * (tobeSpawned.transform.rotation.eulerAngles.z)) / 180;
        var cos = MathF.Round(MathF.Cos(radians), 2);
        float sin = MathF.Round(MathF.Sin(radians), 2);

        Debug.Log("cos= " + cos + " sin= " + sin + "ANGLE= " + tobeSpawned.transform.rotation.eulerAngles.z);

        GameObject blackLine = Instantiate(tobeSpawned, currentLine.position + new Vector3(currentLine.localScale.x/2 + (float)cos * (tobeSpawned.transform.localScale.x/2), 
                                            (float)sin * (tobeSpawned.transform.localScale.x / 2), 0), tobeSpawned.transform.rotation);
        //else currentLine = Instantiate(LineFab, currentLine.position + Vector3.up * 2, Quaternion.identity).transform;
        currentLine = blackLine.transform; 
    }
}
