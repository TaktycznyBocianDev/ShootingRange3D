using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesSpawn : MonoBehaviour
{
    public Image pic;

    private int tmp = 0;

    private void Start()
    {
        tmp = 0;
    }

    public void TestColorChanger()
    {
        if (tmp % 2 == 0)
        {
            pic.color = Color.green;
        }
        else pic.color = Color.red;

        tmp++;
    }
}
