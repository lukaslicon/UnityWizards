using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TestHealthBarAnim : MonoBehaviour
{
    public Image healthbarImage;
    public RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        healthbarImage = gameObject.GetComponent<Image>();
        rt = gameObject.GetComponent<RectTransform>();
        StartCoroutine(ShakeDelay());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator ShakeDelay()
    {
        float delay = 0.5f;
        float startPos = rt.localPosition.y;
        for (int i = 0; i < 10; i += 1) {
            yield return new WaitForSeconds(delay);
            rt.DOShakePosition(0.5f, strength: 20);
            //rt.DOShakeRotation(0.5f);
            //rt.DOLocalMoveY(startPos + 10, delay).SetEase(Ease.InOutBounce);
            //yield return new WaitForSeconds(delay);
            //rt.DOLocalMoveY(startPos - 10, delay).SetEase(Ease.InOutBounce);
            //yield return new WaitForSeconds(delay);
            //rt.DOLocalMoveY(startPos, delay).SetEase(Ease.InOutBounce);
            yield return new WaitForSeconds(2);
            //rt.DO
        }
    }
}
