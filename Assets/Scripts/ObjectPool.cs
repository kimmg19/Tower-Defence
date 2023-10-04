using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] int poolSize = 5;

    GameObject[] pool;

    void Awake() {
        PopulatePool();
    }

    void Start() {
        StartCoroutine("SpawnEnemy");
    }

    private void PopulatePool() {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++) {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }

    }
    private void EnableObjectPool() {
        for(int i=0;i< pool.Length; i++) {

            if (pool[i].activeInHierarchy == false) {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy() {
        while (true) {
            EnableObjectPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }



    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StopCoroutine("SpawnEnemy");


        }
    }
}
