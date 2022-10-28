using System.Collections.Generic;
using UnityEngine;

public class WitchControler : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Rigidbody2D rb2D;
    public GameObject prefabRef;

    [Header("Player variable")]
    [SerializeField] private float speed;

    [Header("Spell variable")]
    [SerializeField] private int spellQuantity;
    public Queue<GameObject> spellPool = new Queue<GameObject>();

    public float WitchSpeed => rb2D.velocity.magnitude;

    private void Awake()
    {
        if (rb2D == null)
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        if (prefabRef != null)
        {
            Init(prefabRef, spellQuantity);
        }
    }

    public void Init(GameObject prefab, int iCnt)
    {
        for (int i = 0; i < iCnt; ++i)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            spellPool.Enqueue(obj);
        }
    }

    void Update()
    {
        float realSpeed = speed * Time.deltaTime * 10;
        rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * realSpeed, Input.GetAxis("Vertical") * realSpeed);
    }

}


