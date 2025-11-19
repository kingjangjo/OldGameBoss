using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSetter : MonoBehaviour
{
    public GameObject destroyEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block") || collision.CompareTag("AttackBlock"))
        {
            var eff = Instantiate(destroyEffect, collision.transform.position, Quaternion.identity);
            Destroy(eff, 0.5f);
            Destroy(collision.gameObject);
        }
    }
}
