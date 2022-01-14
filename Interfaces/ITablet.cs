namespace Interfaces
{
    public interface ITablet
    {
        string GUID { get; set; }
        string Model { get; set; }
        IProducer Producer { get; set; }
        Poda.Tablets.Core.DisplayType Display { get; set; }
        int Price { get; set; }
    }
}
