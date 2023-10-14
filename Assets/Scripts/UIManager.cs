using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [SerializeField] private GameObject HeadShotPopup;
    [SerializeField] private GameObject MissPopup;
    [SerializeField] private GameObject HitPopup;
    [SerializeField] private GameObject CoinText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject MenuPanel;

    private GameObject RePlayButton;
    private void Awake()
    {
        instance = this; 
    }
 
    void Start()
    {
        coinText = CoinText.GetComponent<TextMeshProUGUI>();
        UpdateCoin();

        RePlayButton = GameObject.Find("Play Again Button");
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

    public async void Miss()
    {
        MissPopup.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        MissPopup.GetComponent<Image>().DOFade(1f, 0.2f);
        await Task.Delay(1000);
        MissPopup.transform.DOScale(0f, 0.2f).SetEase(Ease.InBack);
        MissPopup.GetComponent<Image>().DOFade(0f, 0.2f);

    }

    public async void Hit()
    {
        HitPopup.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        HitPopup.GetComponent<Image>().DOFade(1f, 0.2f);
        await Task.Delay(1000);
        HitPopup.transform.DOScale(0f, 0.2f).SetEase(Ease.InBack);
        HitPopup.GetComponent<Image>().DOFade(0f, 0.2f);
    }

    public void CloseMenu()
    {      
    
        MenuPanel.transform.DOMoveY(-20f, 0.2f).SetEase(Ease.OutBack);
        
    }

    public void UpdateCoin() {
        coinText.SetText(PlayerPrefs.GetInt("Coins").ToString());
    }

    public void RePlayButtonActive()
    {     
        RePlayButton.SetActive(true);
    }
    public void ReStart()
    {
        RePlayButton.SetActive(false);      
    }

}
