using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    private void Update()
    {
        transform.localRotation = Quaternion.Euler(90, -1 * transform.parent.rotation.eulerAngles.y , 0);
    }

    private void FixedUpdate()
    {
        transform.position = transform.parent.position + Vector3.forward + Vector3.up * 3;
    }

    public void UpdateBar(float percent)
    {
        if (percent >=0 && percent <= 1)
        {
            bar.fillAmount = percent;
        }
    }



}
