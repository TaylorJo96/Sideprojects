using System;
using System.Collections.Generic;
using System.Text;

namespace PetElevator.Shared
{
    public class Customer : Person, IBillable
    {



        public string PhoneNumber { get; set; }
        public List<string> Pets { get; set; }

        public Customer(string firstName, string lastName, string phoneNumber) : base(firstName, lastName)
        {
            this.PhoneNumber = phoneNumber;
        }
        public Customer(string firstName, string lastName) : base(firstName, lastName)
        {
            this.PhoneNumber = "";
        }

        public double GetBalanceDue(Dictionary<string, double> servicesRendered)
        {
            double getAmountOwed = 0;
            foreach (KeyValuePair<string,double> kvp in servicesRendered)
            {
                getAmountOwed += kvp.Value;

            }
            return getAmountOwed;

        }
    }

}
