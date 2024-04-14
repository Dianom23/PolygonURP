using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Transformer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("UpScale")]
    private void UpScale()
    {
        transform.localScale = Vector3.one * 5;
    }
    [ContextMenu("DownScale")]
    private void DownScale()
    {
        transform.localScale = Vector3.one;
    }

    [ContextMenu("SlowScaling")]
    private void StartSlowScaling()
    {
        StartCoroutine(SlowScaling());
    }

    private IEnumerator SlowScaling()
    {
        while (transform.localScale.x < 5)
        {
            transform.localScale += Time.deltaTime * Vector3.one;
            yield return null;
        }

    }
}
