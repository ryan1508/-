using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject attackRange;
    [SerializeField] private Transform effectRoot;
    [SerializeField] private float attackTime;
    [SerializeField] private float pattern1;
    [SerializeField] private Animator Animator;
    private GameObject _gameObject;
    private Material _material;
    [SerializeField]private BossAattackRange Range;
    private float p1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTime += Time.deltaTime;
        if (attackTime > 5)
        {
            if (p1 > pattern1)
            {
                p1 = 0;
                attackTime = 0;
                _gameObject.SetActive(false);
                _gameObject = null;
                _material = null;
                JumpAttack(false);

                StartCoroutine(StateReset());
                
                return;
            }

            JumpAttack(true);
            if (_gameObject == null)
            {
                _gameObject = Instantiate(attackRange, effectRoot.transform);
                _gameObject.SetActive(true);

                var r=UnityEngine.Random.Range(3, 11);
                
                _gameObject.transform.localScale = new Vector3(r, r ,r);
                
                if(_material == null)
                    _material = _gameObject.GetComponent<Renderer>().material;
            }
            
            p1 += Time.deltaTime;
            if(_material != null)
                Range.DrawCircle(_material,p1/pattern1); 
        }
    }

    private void JumpAttack(bool isJump)
    {
        if (isJump)
        {
            Animator.SetBool("JumpAttack",true);
            Animator.SetBool("DownAttack",false);
        }
        else
        {
            Animator.SetBool("JumpAttack",false);
            Animator.SetBool("DownAttack",true);
        }
    }

    private IEnumerator StateReset()
    {
        yield return new WaitForSeconds(1f);
        
        Animator.SetBool("JumpAttack",false);
        Animator.SetBool("DownAttack",false);
    }
}
