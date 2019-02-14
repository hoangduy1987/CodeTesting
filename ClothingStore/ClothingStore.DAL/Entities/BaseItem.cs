using ClothingStore.Common;

namespace ClothingStore.DAL
{
    public class BaseItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public SizeEnum Size { get; set; }
        public ColorEnum Color { get; set; }
        public bool Public { get; set; }
        public double ImportPrice { get; set; }
        public double RetailPrice { get; set; }
    }
}
