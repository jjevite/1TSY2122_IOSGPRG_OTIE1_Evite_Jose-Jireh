using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit") || collision.CompareTag("Enemy"))
        {
            Vector3 dir = collision.transform.position - transform.parent.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            anim.SetBool("inRange", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit") || collision.CompareTag("Enemy"))
        {
            anim.SetBool("inRange", false);
        }
      
    }
}
