using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] public GameObject launcherreference;

    private void OnTriggerEnter(Collider collision)
    {
        launcherreference.GetComponent<Launcher>().Enemysleft = launcherreference.GetComponent<Launcher>().Enemysleft - 1;
    }
}
