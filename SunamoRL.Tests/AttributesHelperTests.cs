using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace SunamoRL.Tests;

public class AttributesHelperTests
{
    private class Car
    {
        [DataMember(Name = "Cena:")]
        public string Price = "100";

        public string Fuel = "CNG";

        public string? Vin = null;
    }

    private static readonly List<FieldInfo> fields = typeof(Car).GetFields().ToList();

    [Fact]
    public void DataMemberOrEmpty_UnknownCaption_GivesEmptyString()
    {
        var mapping = new Dictionary<string, string> { { "Palivo:", "Fuel" }, { "VIN:", "Vin" } };
        var captions = new List<string> { "", "Cena:", "Palivo:", "VIN:", "Not on the page:" };

        var result = AttributesHelper.DataMemberOrEmpty(new Car(), fields, captions, mapping);

        Assert.Equal(new object[] { "", "100", "CNG", "", "" }, result);
    }

    [Fact]
    public void DataMemberOrEmpty_WithoutMapping_FallsBackToFieldName()
    {
        var result = AttributesHelper.DataMemberOrEmpty(new Car(), fields, new List<string> { "Fuel", "Missing" });

        Assert.Equal(new object[] { "CNG", "" }, result);
    }

    [Fact]
    public void DataMember_UnknownCaption_StillThrows()
    {
        var mapping = new Dictionary<string, string> { { "Palivo:", "Fuel" } };

        Assert.Throws<KeyNotFoundException>(() => AttributesHelper.DataMember(new Car(), fields, new List<string> { "Not on the page:" }, mapping));
    }
}
