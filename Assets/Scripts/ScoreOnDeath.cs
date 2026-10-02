using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour {
    public int amount;

    void Awake() {
        Life life = GetComponent<Life>();
        life.onDeath.AddListener(GivePoints);
    }

    void OnDestroy() {
        Life life = GetComponent<Life>();
        life.onDeath.RemoveListener(GivePoints);
    }

    void GivePoints() {
        ScoreManager.instance.amount += amount;
    }
}
