using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SaveDate
{
    [Serializable]
    public class PlayerPrefsData
    {
        public int SceneIndex;
        public Vector3 HeroPosition;
        public List<Item> Items;
        public List<Weapon> Weapons;
    }

}
