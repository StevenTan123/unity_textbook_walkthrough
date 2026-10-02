using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;

    // Start is called before the first frame update
    void Start() {
        WavesManager.instance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    void Spawn() {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    void EndSpawner() {
        WavesManager.instance.RemoveWave(this);
        CancelInvoke();
    }
}
