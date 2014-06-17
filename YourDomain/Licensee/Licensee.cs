using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;

namespace Keymaster.Licensee
{
    public class Licensee : Aggregate,
        IApplyEvent<LicenseeCreated>
    {
        public bool AlreadyHappened { get; private set; }

        public void Apply(LicenseeCreated e)
        {
            AlreadyHappened = true;
        }
    }
}