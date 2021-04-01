//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BuildCommandComponent buildCommand { get { return (BuildCommandComponent)GetComponent(GameComponentsLookup.BuildCommand); } }
    public bool hasBuildCommand { get { return HasComponent(GameComponentsLookup.BuildCommand); } }

    public void AddBuildCommand(TowerType newTowerType, UnityEngine.Transform newBuildPlace) {
        var index = GameComponentsLookup.BuildCommand;
        var component = (BuildCommandComponent)CreateComponent(index, typeof(BuildCommandComponent));
        component.TowerType = newTowerType;
        component.BuildPlace = newBuildPlace;
        AddComponent(index, component);
    }

    public void ReplaceBuildCommand(TowerType newTowerType, UnityEngine.Transform newBuildPlace) {
        var index = GameComponentsLookup.BuildCommand;
        var component = (BuildCommandComponent)CreateComponent(index, typeof(BuildCommandComponent));
        component.TowerType = newTowerType;
        component.BuildPlace = newBuildPlace;
        ReplaceComponent(index, component);
    }

    public void RemoveBuildCommand() {
        RemoveComponent(GameComponentsLookup.BuildCommand);
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

    static Entitas.IMatcher<GameEntity> _matcherBuildCommand;

    public static Entitas.IMatcher<GameEntity> BuildCommand {
        get {
            if (_matcherBuildCommand == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BuildCommand);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBuildCommand = matcher;
            }

            return _matcherBuildCommand;
        }
    }
}
