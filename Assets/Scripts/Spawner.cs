using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public UnityEngine.Events.UnityEvent onFinish;

    private void Start()
    {
        var spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (var spawnPoint in spawnPoints)
        {
            var choice = gameObjects[Random.Range(0, gameObjects.Capacity)];
            var instance = Instantiate(choice, spawnPoint.transform.position, Quaternion.identity, transform);
        }
        StartCoroutine(Check());
    }

    private IEnumerator Check()
    {
        var childern = transform.Cast<Transform>().ToList();
        while (childern.Any(child => child.gameObject.activeSelf))
        {
            yield return new WaitForSeconds(1.0f);
        }
        onFinish.Invoke();
    }
}
