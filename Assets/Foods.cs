using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Foods : MonoBehaviour
{
    public List<GameObject> foods = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                foods.Add(transform.GetChild(i).gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPosition()
    {
        foreach (GameObject g in foods)
        {
            ResetObjectPosition(g);
            //Rigidbody gRigidBody = g.GetComponent<Rigidbody>();
            g.SetActive(false);
            g.SetActive(true);
        }
    }

    public void ResetObjectPosition(GameObject _go)
    {
        _go.transform.position = new Vector3(transform.position.x + Random.Range(0f, 0.5f), transform.position.y, transform.position.z + Random.Range(0f, 0.5f));
    }
}
