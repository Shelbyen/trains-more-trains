using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Guard : Human
{
    [SerializeField] float radius;
    [SerializeField] bool post;
    private void FixedUpdate()
    {
        if (!post)
        {
            return;
        }
        List<RaycastHit2D> colliderHits = new List<RaycastHit2D>();
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        Physics2D.CircleCast(transform.position, radius, Vector2.up, filter, colliderHits, Mathf.Infinity);
        foreach (RaycastHit2D hit in colliderHits)
        {
            if (hit.transform.GetComponent<Passenger>().GetNoticed()) continue;
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, new Vector2(hit.transform.position.x - transform.position.x, hit.transform.position.y - transform.position.y), radius);
            if (!raycastHit) continue;
            hit.transform.GetComponent<Passenger>().SetNoticed(true);
            Debug.Log("FFFF");
        }
    }
}
