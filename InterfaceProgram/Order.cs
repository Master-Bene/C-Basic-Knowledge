namespace InterfaceProgram
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal Price { get; set; }
        public bool IsDeliver { get; set; }

        public ShipMent ShipMent { get; set; }

    }
}
