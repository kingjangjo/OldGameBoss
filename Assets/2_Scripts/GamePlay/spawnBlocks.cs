using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class spawnBlocks : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    public float waitTime;
    
    private List<float> rotations = new List<float>();
    private GameObject player;

    private Coroutine spawnCoroutine;
    
    void Start()
    {
        // 0, 90, 180, 270
        for (int i = 0; i < 4; i++)
        {
            rotations.Add(i*90);
        }
        
        player = GameObject.FindWithTag("Player");
        DelegateManager.instance.onGameOver += StopSpawn;
        DelegateManager.instance.onGameClear += StopSpawn;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DelegateManager.instance.onGameOver += StopSpawn;
        DelegateManager.instance.onGameClear += StopSpawn;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        DelegateManager.instance.onGameOver -= StopSpawn;
        DelegateManager.instance.onGameClear -= StopSpawn;
    }

    IEnumerator spawnBlock()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Vector2 pos = new Vector2(Mathf.Clamp(player.transform.position.x, -3.8f, 3.8f), transform.position.y);
            Quaternion rotation = Quaternion.Euler(0, 0, rotations[Random.Range(0, rotations.Count)]);
            Instantiate(blocks[Random.Range(0, blocks.Count)], pos, rotation);
        }
    }

    void StopSpawn()
    {
        StopCoroutine(spawnCoroutine);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        spawnCoroutine = StartCoroutine(spawnBlock());
    }
}
