using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Foods : MonoBehaviour
{
    public List<GameObject> foods = new List<GameObject>();
    public int numItemsToSpawn = 4;
    public float spawnZOffset = 1f;
    public float spawnSafetyThreshold = .2f;

    TrayMoveForward tray;
    Vector3 traySize;
    Vector3 trayCenter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        /*for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                foods.Add(transform.GetChild(i).gameObject);
            }
        }*/

        tray = FindFirstObjectByType<TrayMoveForward>();

        traySize = tray.GetComponent<BoxCollider>().size;
        traySize = tray.GetComponent<BoxCollider>().center;

        int n = foods.Count;
        for (int i = 0; i < numItemsToSpawn; i++)
        {
            Spawn(foods[Random.Range(0, n)]);
        }
    }

    void Spawn(GameObject food)
    {
        Vector3 randomLocation = new Vector3(Random.Range(spawnSafetyThreshold, traySize.x - spawnSafetyThreshold), 
            traySize.y, Random.Range(spawnSafetyThreshold, traySize.z - spawnSafetyThreshold));
        randomLocation = randomLocation - traySize * .5f + trayCenter;
        randomLocation = tray.transform.TransformPoint(randomLocation);
        randomLocation.y += spawnZOffset;
        Instantiate(food, randomLocation, Random.rotationUniform);
    }

    public void ResetPosition()
    {
        /*foreach (GameObject g in foods)
        foods.RemoveAll(x => x == null);

        foreach (GameObject g in foods)
        {
            ResetObjectPosition(g);
            //Rigidbody gRigidBody = g.GetComponent<Rigidbody>();
            g.SetActive(false);
            g.SetActive(true);
        }*/
    }

    public void ResetObjectPosition(GameObject _go)
    {
        //_go.transform.position = new Vector3(transform.position.x + Random.Range(0f, 0.5f), transform.position.y, transform.position.z + Random.Range(0f, 0.5f));
    }
}
