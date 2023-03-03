using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCell : MonoBehaviour
{
    private Image gridImage;
    void Start()
    {
        gridImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Highlight()
    {
        //StopAllCoroutines();
        gridImage.color = Constant.gridHighlight;
        StartCoroutine("ChangeColor");
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(1);
        //yield return null;
        gridImage.color = Constant.gridColor;
    }
}
