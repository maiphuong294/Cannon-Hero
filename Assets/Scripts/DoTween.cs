using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DoTween : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Ease ease;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        DoAnim();

    }
    [ContextMenu("DoAnim")]
    private async void DoAnim()
    {
        transform.position = new Vector3(-8f, 0f, 0f);
        //transform.position = Vector3.zero;
        transform.localScale = Vector3.one;
        transform.rotation = Quaternion.identity;
        await Task.Delay(500);
        //code below

        transform.DOMoveX(5f, 1f).SetEase(ease);
        //khong truyen vao looptype -> default la restart

        //transform.DOScale(0.3f, 1f).OnUpdate(() => { Debug.Log("Update"); });
        //transform.DORotate(Vector3.forward * 1000, 1f, RotateMode.FastBeyond360);


        //spriteRenderer.DOFade(0f, 1f);
    }


}
