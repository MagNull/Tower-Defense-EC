//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BuildingClickComponent buildingClick { get { return (BuildingClickComponent)GetComponent(GameComponentsLookup.BuildingClick); } }
    public bool hasBuildingClick { get { return HasComponent(GameComponentsLookup.BuildingClick); } }

    public void AddBuildingClick(UnityEngine.Transform newBuildingPlace, UnityEngine.Vector3 newCursorPosition, bool newIsBuilding) {
        var index = GameComponentsLookup.BuildingClick;
        var component = (BuildingClickComponent)CreateComponent(index, typeof(BuildingClickComponent));
        component.BuildingPlace = newBuildingPlace;
        component.CursorPosition = newCursorPosition;
        component.IsBuilding = newIsBuilding;
        AddComponent(index, component);
    }

    public void ReplaceBuildingClick(UnityEngine.Transform newBuildingPlace, UnityEngine.Vector3 newCursorPosition, bool newIsBuilding) {
        var index = GameComponentsLookup.BuildingClick;
        var component = (BuildingClickComponent)CreateComponent(index, typeof(BuildingClickComponent));
        component.BuildingPlace = newBuildingPlace;
        component.CursorPosition = newCursorPosition;
        component.IsBuilding = newIsBuilding;
        ReplaceComponent(index, component);
    }

    public void RemoveBuildingClick() {
        RemoveComponent(GameComponentsLookup.BuildingClick);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBuildingClick;

    public static Entitas.IMatcher<GameEntity> BuildingClick {
        get {
            if (_matcherBuildingClick == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BuildingClick);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBuildingClick = matcher;
            }

            return _matcherBuildingClick;
        }
    }
}
