using System.Collections.Generic;

namespace PetElevator.Shared
{
    interface IBillable
    {
        double GetBalanceDue(Dictionary<string, double> servicesRendered);
    }
}
