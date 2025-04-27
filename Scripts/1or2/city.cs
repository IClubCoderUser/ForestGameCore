using UnityEngine;

[Entity]
public class city : UnitSelectHelper
{
    public byte Country;
    public byte the_level_of_development_of_the_city;

    private long ID { get; set; }

    public override bool IsBuild => true;
}
