using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnUi: MonoBehaviour
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

        private Button Button1;
        private Button Button2;
        private Button Button3;

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

        public bool isAttacker = true;
        private List<SpawnPoint> spawnPoints;

        private void Start()
        {
                spawnPoints = isAttacker ? GameMap.unitSpawnPoints : GameMap.structureSpawnPoints;
                SpawnPointDropdown.ClearOptions();
                foreach (var spawnPoint in spawnPoints)
                {
                        var optionsData = new TMP_Dropdown.OptionData
                        {
                                text = spawnPoint.name
                        };
                        SpawnPointDropdown.options.Add(optionsData);
                }

                SpawnPointDropdown.value = 0;
                

                // This isn't SOLID coding, but chosen to speed up implementation
                var buttons = gameObject
                        .Children()
                        .Where(gO => gO.GetComponent<Button>() != null)
                        .ToList();
                
                if (isAttacker)
                {
                        Button1 = buttons[0].GetComponent<Button>();
                        Button2 = buttons[1].GetComponent<Button>();
                        Button3 = buttons[2].GetComponent<Button>();
                        Button1
                                .onClick
                                .AddListener(() => SpawnUnit(UnitType.Tank));
                        Button2
                                .onClick
                                .AddListener(() => SpawnUnit(UnitType.Humvee));
                        Button3
                                .onClick
                                .AddListener(() => SpawnUnit(UnitType.Brute));
                }
                else
                {
                        Button1 = buttons[0].GetComponent<Button>();
                        Button2 = buttons[1].GetComponent<Button>();
                        Button1
                                .onClick
                                .AddListener(() => SpawnUnit(UnitType.MissileLauncher));
                        Button2
                                .onClick
                                .AddListener(() => SpawnUnit(UnitType.Turret));
                }

        }

        private void SpawnUnit(UnitType unitType)
        {
                var selectedSpawnPoint = GetSpawnPoint();
                selectedSpawnPoint.SpawnUnit(unitType);
        }

        private SpawnPoint GetSpawnPoint()
        {
                return spawnPoints.FirstOrDefault(s =>
                        s.name == SpawnPointDropdown
                                .options[SpawnPointDropdown.value]
                                .text
                        );
        }
}