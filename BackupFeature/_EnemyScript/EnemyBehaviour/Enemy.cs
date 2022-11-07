using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    // Reference the SCO
    public EnemyDataSCO enemyManagerSCO;

    // Reference for sco data
    public int enemyHealth;
    public int enemyDamage;
    public float enemySpeed;
    public float enemyAttackSpeed;

    // Reference for PrimaryStats Object
    public Slider enemyHealthBar;

    // Refrence for target transform
    public GameObject targetLocation;

    public float enemyDuration = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        // SCO
        enemyHealth = enemyManagerSCO.enemyHealth;
        enemyDamage = enemyManagerSCO.enemyDamage;
        enemySpeed = enemyManagerSCO.enemySpeed;
        enemyAttackSpeed = enemyManagerSCO.enemyAttackSpeed;

        // Reference Enemy
        enemyHealthBar.maxValue = enemyHealth;
        enemyHealthBar.value = enemyHealth;
    }

    private void Start()
    {
        StartCoroutine(waitEnemyMove());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator waitEnemyMove()
    {
        yield return new WaitForSeconds(5);
        transform.DOMove(targetLocation.transform.position, enemyDuration);
    }

}
