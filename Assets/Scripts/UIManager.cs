using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [SerializeField] private GameObject HeadShotPopup;
    private void Awake()
    {
        instance = this; 
    }
 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void HeadShot()
    {
        HeadShotPopup.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        HeadShotPopup.GetComponent<Image>().DOFade(1f, 0.2f);
        await Task.Delay(1000);
        HeadShotPopup.transform.DOScale(0f, 0.2f).SetEase(Ease.InBack);
        HeadShotPopup.GetComponent<Image>().DOFade(0f, 0.2f);

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
