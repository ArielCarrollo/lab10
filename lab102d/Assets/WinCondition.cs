using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] public GameObject launcherreference;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        launcherreference.GetComponent<Launcher>().Enemysleft = launcherreference.GetComponent<Launcher>().Enemysleft - 1;
    }
}
