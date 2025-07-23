namespace SampleTracking.Domain;

public class Sample
{
    public int Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Шифр
    /// </summary>
    public required string Code { get; set; }
}
