using Fusion;
using System.Collections;
using UnityEngine;



public struct HelloWordTextInput : INetworkInput
{
    //public Vector3 aimDirection;
    public int count;
}

public class HelloWordText : NetworkBehaviour
{
    private TextMesh textMesh;
    private int cnt = 0;

    [Networked(OnChanged=nameof(CountAgainChanged))] public int CountAgain { get; set; }

    private void Awake()
    {
        this.textMesh = GetComponentInChildren<TextMesh>();

    }

    private void OnEnable()
    {
        this.cnt = 0;    
        StartCoroutine(UpdateText());
	}

    private void OnDisable()
    {
        StopCoroutine(UpdateText());        
    }

    protected static void CountAgainChanged(Changed<HelloWordText> changed)
    {
        changed.LoadNew();
        var newVal = changed.Behaviour.CountAgain;

        Debug.Log(newVal);

        //if (this.textMesh != null)
        //{
        //    this.textMesh.text = $"Time = {this.CountAgain}";
        //}

    }

    private IEnumerator UpdateText()
    {
        for (; ; )
        {
            this.CountAgain = cnt++;

            yield return new WaitForSeconds(1f);
        }
    }
}