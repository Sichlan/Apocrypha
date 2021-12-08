namespace Apocrypha.CommonObject.Models
{
    public class Item : DatabaseObject
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}