using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleController : MonoBehaviour {

    public Adventurer Player;
    public Adventurer Enemy;

    public enum BattleStates {  Idle, Choose, Show, Summary, Victory, Defeat}
    public BattleStates state = BattleStates.Idle;

    public Canvas BattleUI;
    public TextMeshProUGUI HealthLabel;
    public TextMeshProUGUI EnemyHealthLabel;
    public TextMeshProUGUI PlayerDamage;

    public void Start()
    {
        //sBattleUI.enabled = false;
    }

    public void Update()
    {
        HealthLabel.text = "Player HP: " + Player.Health.ToString() + "/" + Player.MaxHealth.ToString();
        EnemyHealthLabel.text = Enemy.Health.ToString() + "/" + Enemy.MaxHealth.ToString();
        PlayerDamage.text = "Player Damage: " + Player.GiveDamage().ToString();
        switch (state)
        {
            case BattleStates.Choose:
                if (Player.isBattleReady)
                {
                    Enemy.RandomAttack();
                    Enemy.isBattleReady = true;
                    state = BattleStates.Show;
                }
                break;

            case BattleStates.Show:
                Enemy.TakeDamage(Player.GiveDamage(), Player.Stance);

                if (Enemy.Health <= 0)
                {
                    state = BattleStates.Victory;
                    Enemy.gameObject.SetActive(false);
                    break;
                }

                Player.TakeDamage(Enemy.Damage, Enemy.Stance);
                Debug.Log("Player: " + Player.GiveDamage().ToString() + " Stance: " + Player.Stance.ToString());
                Debug.Log("Enemy: " + Enemy.GiveDamage().ToString() + " Stance: " + Enemy.Stance.ToString());

                if (Player.Health <= 0)
                    state = BattleStates.Defeat;                
                else        
                    state = BattleStates.Choose;

                break;

            case BattleStates.Victory:
                EndBattle();
                break;
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartBattle();
            GetComponent<BoxCollider>().enabled = false;
        }

        
    }

    public void StartBattle()
    {
        BattleUI.enabled = true;
        state = BattleStates.Choose;
        Player.gameObject.GetComponent<Movement>().enabled = false;
    }

    public void EndBattle()
    {
        state = BattleStates.Idle;
        BattleUI.enabled = false;
        Player.gameObject.GetComponent<Movement>().enabled = true;
        Destroy(gameObject);
    }



}
