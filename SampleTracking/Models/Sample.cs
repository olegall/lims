namespace SampleTracking.Models;

public class Sample
{
    public int Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Шифр
    /// </summary>
    public string Code { get; set; }
}
