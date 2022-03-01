using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class DamageIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject target;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        }
    }

    public void Show(GameObject target, int damage)
    {
        this.target = target;
        text.text = damage.ToString();
        animator.SetTrigger("show_trigger");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
