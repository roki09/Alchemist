using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public static class LibraryMethods
{
    public static int GetRendomRaryti()
    {
        int chanceDrop = Random.Range(0, 101);
        if (chanceDrop > 95)
            return 3;
        else if (chanceDrop < 95 && chanceDrop > 80)
            return 2;
        else if (chanceDrop > 80 && chanceDrop > 50)
            return 1;
        else return 0;
    }

    public static void MainHeroGetDamage(int damage, MainHero mainHero, TextMeshProUGUI heroHp)
    {
        mainHero._currentHealth -= damage;
        heroHp.text = $"{mainHero._currentHealth}";
    }

    public static void GetColor(TextMeshProUGUI text, Item item)
    {
        switch (item.rarity)
        {
            case 0:
                break;

            case 1:
                text.color = Color.green;
                break;

            case 2:
                text.color = Color.blue;
                break;

            case 3:
                text.color = Color.yellow;
                break;

        }
    }

}
