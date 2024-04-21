namespace Common
{
    public class CreateBuildingContract
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Floors { get; set; }
    }
}