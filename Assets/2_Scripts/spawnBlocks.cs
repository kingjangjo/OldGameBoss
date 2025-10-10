using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBlocks : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    public float waitTime;
    
    private List<float> rotations = new List<float>();
    private GameObject player;
    
    void Start()
    {
        StartCoroutine(spawnBlock());
    
        // 0, 90, 180, 270
        for (int i = 0; i < 4; i++)
        {
            rotations.Add(i*90);
        }
        
        player = GameObject.FindWithTag("Player");
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
}
