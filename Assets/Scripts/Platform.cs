using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentIndexPoint = 0;
    [SerializeField] private float speed = 2f;

    void Update()
    {
        if(Vector2.Distance(waypoints[currentIndexPoint].transform.position, transform.position)< 0.1f)
        {
            currentIndexPoint++;
            if (currentIndexPoint >= waypoints.Length)
                currentIndexPoint = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentIndexPoint].transform.position, 
            Time.deltaTime * speed);
    }
}
