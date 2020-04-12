using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Updater : MonoBehaviour
{
    public Spawner spawner;
    public Text score;

    private void Start()
    {
        StartCoroutine(UpdateScore());
    }

    private IEnumerator UpdateScore()
    {
        while (true)
        {
            int count = spawner.transform.Cast<Transform>().Count(child => !child.gameObject.activeSelf);
            score.text = $"Alpacas {count}/{spawner.transform.childCount}";
            yield return new WaitForSeconds(1.0f);
        }
    }
}
