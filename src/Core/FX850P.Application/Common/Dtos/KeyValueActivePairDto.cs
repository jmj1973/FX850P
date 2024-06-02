namespace FX850P.Application.Common.Dtos
{
    public class KeyValueActivePairDto<TType>
    {
        public TType Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool Active { get; set; }
    }
}
