using System.Collections.Generic;
using UnityEngine;

public class WitchAttack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
   [SerializeField] private List<Transform> firPoint = new List<Transform>();
    private GameObject spell;
    float cooldawnTimer = Mathf.Infinity;
    private WitchControler WitchControler;


    private void Awake()
    {
        WitchControler = GetComponent<WitchControler>();
    }

    private void Update()
    {
        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && cooldawnTimer > attackCooldown)
        {
            Attack();
        }
        
       
        cooldawnTimer += Time.deltaTime;
    }
   
    private void Attack()
    {
        Debug.Log("Attack");
        cooldawnTimer = 0;
        for(int i=0; i < firPoint.Count; i++)
        {
            SetObject(firPoint[i].position, firPoint[i].rotation);
            spell.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
        

    }


    public void SetObject(Vector3 iPosition, Quaternion iRotation)
    {
        spell = WitchControler.spellPool.Dequeue();

        spell.transform.position = iPosition;
        spell.transform.rotation = iRotation;
        spell.SetActive(true);
        WitchControler.spellPool.Enqueue(spell);
    }


}
