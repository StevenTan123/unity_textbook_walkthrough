using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start() {
        print("test start");
    }

    // Update is called once per frame
    void Update() {
        print("test");   
    }

    void OnDestroy() {
        print("destroyed");
    }
}
