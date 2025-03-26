using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer1 : MonoBehaviour
{
    public float countTime = 0f; // 计时器

    void Update()
    {
        CountTime(); // 在 Update 中调用计时方法
    }

    void CountTime()
    {
        countTime += Time.deltaTime; // 每帧增加时间
        if (countTime >= 15f) // 如果计时器达到 15 秒
        {
            SceneManager.LoadScene(2); // 跳转到场景编号为 2 的场景
        }
    }
}