using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour {

    public int MaxHealth;
    public int Health;
    public int Damage; 
    public int Multiplier;

    public int AttackThreshold, MagicThreshold, CounterThreshold;
    
    public enum TypeOfDamage { Attack, Magic, Counter }
    public TypeOfDamage Stance;
    public bool isBattleReady = false;

    public Weapon weapon;
    public Armor armor;
    
    // After each battle the players health will be returned. This can also be used when equiping new armor to set new health
    public void ResetHealth()
    {
        if (armor != null)
        {
            MaxHealth = armor.health;
            Health = MaxHealth;
        }
        else
            Health = MaxHealth;
    }

    // If weapon is equiped take that damage instead of base damage
    public int GiveDamage()
    {
        if (weapon != null)
            return weapon.damage;
        else
            return Damage;
    }

    // How an adventurer takes damage. Depending on the stance the damage will be increased or multiplied in a rock paper scissors way.
    // Attack Beats Magic
    // Magic Beats Counter
    // Counter Beats Attack
    // EX: If a Player attack were to do 4 damage and picked attack, and the Enemy would do 4 damage and picked Magic:
    // Player would do 6 Damage
    // Enemy would do 2 Damage
	public void TakeDamage(int damage, TypeOfDamage tod)
    {
        isBattleReady = false;

        if(tod == Stance)
            Health -= damage;

        switch (Stance)
        {
            case TypeOfDamage.Attack:
                if (tod == TypeOfDamage.Counter)
                {
                    Health -= damage + ( damage / Multiplier);
                }
                if (tod == TypeOfDamage.Magic)
                {
                    Health -= damage / Multiplier;
                }
                break;
            case TypeOfDamage.Magic:
                if (tod == TypeOfDamage.Attack)
                {
                    Health -= damage + (damage / Multiplier);
                }
                if (tod == TypeOfDamage.Counter)
                {
                    Health -= damage / Multiplier;
                }
                break;
            case TypeOfDamage.Counter:
                if (tod == TypeOfDamage.Magic)
                {
                    Health -= damage + (damage / Multiplier);
                }
                if (tod == TypeOfDamage.Attack)
                {
                    Health -= damage / Multiplier;
                }
                break;
        }     
    }
    public void ChooseAttack(int tod)
    {
        Stance = (TypeOfDamage)tod;
        isBattleReady = true;
    }

    public void RandomAttack()
    {
        int rand = Random.Range(0, 100);

        if (rand >= 0 && rand <= AttackThreshold)
        {
            Stance = TypeOfDamage.Attack;
        }
        else if (rand > AttackThreshold && rand <= MagicThreshold)
        {
            Stance = TypeOfDamage.Magic;
        }
        else if (rand >= MagicThreshold && rand < CounterThreshold)
        {
            Stance = TypeOfDamage.Counter;
        }
        else
        {
            Debug.Log("Rerolled");
            RandomAttack();
        }
        
    }
}
