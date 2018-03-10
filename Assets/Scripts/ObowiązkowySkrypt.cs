using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLakeJam
{
    public class ObowiązkowySkrypt : MonoBehaviour
    {
        void Start()
        {
            foreach (Rigidbody2D rb in FindObjectsOfType<Rigidbody2D>())
            {
                if (rb.GetComponent<Rigidbody2D>().gravityScale != 0)
                {
                    throw new UnityException("To nie przejdzie xD");
                }
            }
        }

    }
}

