namespace AutoMapperSandbox.Models
{
    public class FruitOutput
    {
        public string Name { get; set; }
        public int PricePerWeight { get; set; }
        public FruitComplexObject Properties { get; set; }
        public string FieldToIgnore { get; set; }
    }
}
