﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic
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
				var buildingEntity = _contexts.game.CreateEntity();
				buildingEntity.AddPosition(e.buildCommand.BuildPlace.position);
				buildingEntity.AddRotation(e.buildCommand.BuildPlace.rotation);
				GameObject building = new GameObject("Tower");
				building.transform.position = e.buildCommand.BuildPlace.position;
				buildingEntity.AddView(building);
				BuildTower(e, building, buildingEntity);
				building.transform.rotation = e.buildCommand.BuildPlace.rotation;

				if (building.TryGetComponent(out EntityLink link))
				{
					link.Link(buildingEntity);
				}
				else
				{
					building.AddComponent<EntityLink>().Link(buildingEntity);
					building.AddComponent<TowerRadiusDrawer>();
				}
				
				e.buildCommand.BuildPlace.gameObject.SetActive(false);

				e.isDestroyed = true;
			}
		}

		private void BuildTower(GameEntity e, GameObject building, GameEntity buildingEntity)
		{
			var globals = _contexts.game.globals.value;
			switch (e.buildCommand.TowerType)
			{
				case TowerType.ARCHER:
					GameObject tower = GameObject.Instantiate(
						_contexts.game.globals.value.ArcherTower,
						building.transform);
				
					buildingEntity.AddShooter(tower.transform.GetChild(0).gameObject, 
						tower.transform.GetChild(0).GetChild(0).GetChild(0),
						TowerType.ARCHER, 
						null,
						globals.ArcherShootDistance,
						globals.ArcherShootDelay);
				
					buildingEntity.AddBuilding(e.buildCommand.TowerType, e.buildCommand.BuildPlace.gameObject,
						new GameObject("Upgrade(TODO)"));
					break;
			}
		}
	}
}
