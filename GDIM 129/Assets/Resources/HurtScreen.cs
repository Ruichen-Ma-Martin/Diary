using UnityEngine;
using UnityEngine.UI;


public class HurtScreen : Singleton<HurtScreen>
{
    
    [Range(0.1f, 0.8f)] public float maxAlpha = 0.3f;
 
    [Range(0.1f, 1f)] public float flashDuration = 0.15f;

    private Image hurtImage;
    private float currentAlpha;
    private bool isFlashing;

    void Awake()
    {
        hurtImage = GetComponent<Image>();
        hurtImage.color = new Color(1, 0, 0, 0);
        gameObject.SetActive(false);
    }

 
    public void Flash()
    {
        gameObject.SetActive(true);
        isFlashing = true;
        currentAlpha = maxAlpha;
        hurtImage.color = new Color(1, 0, 0, currentAlpha);
    }

    void Update()
    {
        if (isFlashing)
        {
            // Öð½¥½µµÍÍ¸Ã÷¶È
            currentAlpha -= Time.deltaTime / flashDuration * maxAlpha;
            if (currentAlpha <= 0)
            {
                currentAlpha = 0;
                isFlashing = false;
                hurtImage.color = new Color(1, 0, 0, currentAlpha);
                gameObject.SetActive(false);
            }
            
        }
    }
}