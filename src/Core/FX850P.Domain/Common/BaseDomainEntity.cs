
namespace FX850P.Domain.Common
{
    public abstract class BaseDomainEntity<TType>
    {
        public TType Id { get; set; } = default(TType)!;
    }
}
