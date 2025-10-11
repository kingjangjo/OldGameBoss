using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLimitLine : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        Block block = other.GetComponent<Block>();
        
        if (block != null)
        {
            Debug.Log($"{block.name} : {block.isThrown} & {block.ignoreLineCheck}");
            // 망치 맞은 블록 무시
            if(block.isThrown) return;
            
            // 생성된 블록 무시
            if(block.ignoreLineCheck) return;
            
            // 게임 종료
            EndGame();
        }
    }

    private void EndGame()
    {
        DelegateManager.instance.onGameOver();   
        // 종료 예)
        Time.timeScale = 0;
    }
    
}