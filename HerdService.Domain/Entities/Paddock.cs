using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class Paddock
{
    public int Id { get; private set; }
    public int FarmId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;
    public decimal AreaHectares { get; private set; }
    public int? GaugedCapacity { get; private set; }
    public string? GrassType { get; private set; }
    public string CurrentStatus { get; private set; } = "AVAILABLE";

    private Paddock() { }

    public Paddock(int farmId, string name, string code, decimal areaHectares, int? gaugedCapacity = null, string? grassType = null)
    {
        if (farmId <= 0) throw new ArgumentException("Invalid FarmId");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");
        if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Code required");
        if (areaHectares < 0) throw new ArgumentException("Area cannot be negative");

        FarmId = farmId;
        Name = name;
        Code = code;
        AreaHectares = areaHectares;
        GaugedCapacity = gaugedCapacity;
        GrassType = grassType;
        CurrentStatus = "AVAILABLE";
    }
}
