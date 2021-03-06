﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {

    public static WaypointManager Instance;                 // Simple Singleton holding a ref to the script

    public List<Path> Paths = new List<Path>();             // List of Stored Paths

	// Use this for initialization
	void Awake () {
        Instance = this;
	}
	
    public Vector3 GetSpawnPosition(int pathIndex)
    {
        return Paths[pathIndex].WayPoints[0].position;      // Returns Enemy Position based on their Spawn Point
    }                                                       // Using the First Waypoint of Chosen Path

	// Update is called once per frame
	void Update () {
		
	}


}

[System.Serializable]
public class Path
{
    public List<Transform> WayPoints = new List<Transform>();
}
