using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WavesGameMode : MonoBehaviour {
    [SerializeField] private Life playerLife;
    [SerializeField] private Life baseLife;

    void Awake() {
        playerLife.onDeath.AddListener(OnPlayerDeath);
        baseLife.onDeath.AddListener(OnPlayerDeath);
        EnemiesManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    void OnDestroy() {
        playerLife.onDeath.RemoveListener(OnPlayerDeath);
        baseLife.onDeath.RemoveListener(OnPlayerDeath);
    }

    void CheckWinCondition() {
        if (EnemiesManager.instance.enemies.Count == 0 && WavesManager.instance.waves.Count == 0) {
            SceneManager.LoadScene("WinScreen");
        }
    }

    void OnPlayerDeath() {
        SceneManager.LoadScene("LoseScreen");
    }
}
