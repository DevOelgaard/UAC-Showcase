using System;
using System.Linq;
using Unity.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiTopLeft: MonoBehaviour
{
        public TMP_Dropdown spawnPointDropdown;
        private TMP_Dropdown SpawnPointDropdown
        {
                get
                {
                        if (spawnPointDropdown == null)
                        {
                                spawnPointDropdown = gameObject
                                        .Child("AttackerDropdown")
                                        .GetComponent<TMP_Dropdown>();
                        }
        
                        return spawnPointDropdown;
                }
        }
        private Button tankButton;

        private Button TankButton
        {
                get
                {
                        if (tankButton == null)
                        {
                                tankButton = gameObject
                                        .Child("TankBtn")
                                        .GetComponent<Button>();
                        }

                        return tankButton;
                }
        }
        private Button humveeButton;
        private Button HumveeButton
        {
                get
                {
                        if (humveeButton == null)
                        {
                                humveeButton = gameObject
                                        .Child("HumveeBtn")
                                        .GetComponent<Button>();
                        }

                        return humveeButton;
                }
        }
        private Button bruteButton;
        private Button BruteButton
        {
                get
                {
                        if (bruteButton == null)
                        {
                                bruteButton = gameObject
                                        .Child("BruteBtn")
                                        .GetComponent<Button>();
                        }

                        return bruteButton;
                }
        }

        private GameMap gameMap;

        private GameMap GameMap
        {
                get
                {
                        if (gameMap == null)
                        {
                                gameMap = GameObject.Find("GameMap").GetComponent<GameMap>();
                        }

                        return gameMap;
                }
        }



        private void Start()
        {
                SpawnPointDropdown.ClearOptions();
                foreach (var spawnPoint in GameMap.unitSpawnPoints)
                {
                        var optionsData = new TMP_Dropdown.OptionData
                        {
                                text = spawnPoint.name
                        };
                        SpawnPointDropdown.options.Add(optionsData);
                }

                SpawnPointDropdown.value = 0;
                
                TankButton
                        .onClick
                        .AddListener(() => SpawnUnit(UnitType.Tank));
                HumveeButton
                        .onClick
                        .AddListener(() => SpawnUnit(UnitType.Humvee));
                BruteButton
                        .onClick
                        .AddListener(() => SpawnUnit(UnitType.Brute));
        }

        private void SpawnUnit(UnitType unitType)
        {
                var selectedSpawnPoint = GetSpawnPoint();
                selectedSpawnPoint.SpawnUnit(unitType);
        }

        private SpawnPoint GetSpawnPoint()
        {
                return GameMap.unitSpawnPoints.FirstOrDefault(s =>
                        s.name == SpawnPointDropdown
                                .options[SpawnPointDropdown.value]
                                .text
                        );
        }
}