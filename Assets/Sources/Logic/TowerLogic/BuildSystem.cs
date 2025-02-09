﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic.TowerLogic
{
	public class BuildSystem : ReactiveSystem<GameEntity> 
	{
		private Contexts _contexts;
    
		public BuildSystem (Contexts contexts) : base(contexts.game) 
		{
			_contexts = contexts;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.BuildCommand);
		}
		
		protected override bool Filter(GameEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameEntity> entities) 
		{
			foreach (var e in entities)
			{
				if (_contexts.game.playerEntity.playerBalance.Balance - GetCost(e.buildCommand.TowerType) >= 0)
				{
					var buildingEntity = _contexts.game.CreateEntity();
					Vector3 position = e.buildCommand.BuildPlace.position;
					Quaternion rotation = e.buildCommand.BuildPlace.rotation;
					buildingEntity.AddPosition(position);
					buildingEntity.AddRotation(rotation);
				
					GameObject building = new GameObject("Tower");
					buildingEntity.AddView(building);

					building.transform.position = position;
					building.transform.rotation = rotation;
				
					BuildTower(e, building, buildingEntity);

					if (building.TryGetComponent(out EntityLink link))
					{
						link.Link(buildingEntity);
					}
					else
					{
						building.AddComponent<EntityLink>().Link(buildingEntity);
						building.AddComponent<TowerRadiusDrawer>();
					}
					_contexts.game.CreateEntity().AddChangeBalance(-buildingEntity.building.Cost);
					e.buildCommand.BuildPlace.gameObject.SetActive(false);
				}
				e.isDestroyed = true;
			}
		}

		private void BuildTower(GameEntity e, GameObject building, GameEntity buildingEntity)
		{
			var globals = _contexts.game.globals.value;
			GameObject tower;
			switch (e.buildCommand.TowerType)
			{
				case TowerType.ARCHER:
					tower = GameObject.Instantiate(
						globals.ArcherTower,
						building.transform);
				
					buildingEntity.AddShooter(
						tower.transform.GetChild(0).gameObject, 
						tower.transform.GetChild(0).GetChild(0).GetChild(0),
						TowerType.ARCHER, 
						null,
						globals.ArcherShootDistance,
						globals.ArcherShootDelay);
				
					buildingEntity.AddBuilding(
						e.buildCommand.TowerType, 
						e.buildCommand.BuildPlace.gameObject,
						new GameObject("Upgrade(TODO)"),
						globals.ArcherTowerCost);
					break;
				case TowerType.MAGE:
					tower = GameObject.Instantiate(
						globals.MageTower,
						building.transform);

					buildingEntity.AddShooter(tower.transform.GetChild(0).gameObject,
						tower.transform.GetChild(1).transform,
						TowerType.MAGE,
						null,
						globals.MageTowerDistance,
						globals.MageShootDelay);
					buildingEntity.AddBuilding(
						e.buildCommand.TowerType,
						e.buildCommand.BuildPlace.gameObject,
						new GameObject("Upgrade(TODO)"), 
						globals.MageTowerCost
						);
					break;
			}
		}

		private int GetCost(TowerType type)
		{
			switch (type)
			{
				case TowerType.ARCHER: return _contexts.game.globals.value.ArcherTowerCost;
				case TowerType.MAGE: return _contexts.game.globals.value.MageTowerCost;
				default:
					Debug.Log("Not Cost");
					return 0;
			}
		}
	}
}
