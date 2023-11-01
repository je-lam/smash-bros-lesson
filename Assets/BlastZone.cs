using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D victim)
    {
        if (victim.tag.Equals("P1"))
        {
            victim.GetComponent<PlayerController>().DieBottom();
        }
    }
}
