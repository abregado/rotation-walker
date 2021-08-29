using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FieldScatterer: MonoBehaviour {
    public float radius = 3;

    public void Start() {
        foreach (Transform child in transform) {
            child.localPosition = new Vector3(Random.Range(radius * -1, radius), 0, Random.Range(radius * -1, radius));
        }
    }
    
}
