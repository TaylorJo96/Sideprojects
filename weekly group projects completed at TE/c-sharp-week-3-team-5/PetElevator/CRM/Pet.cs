using System;
using System.Collections.Generic;
using System.Text;


namespace PetElevator.CRM
{
    public class Pet
    {
        public string PetName { get; set; }
        public string Species { get; set; }
        public List<string> Vaccinations { get; set; }


        public Pet(string name, string species)
        {
            this.PetName = name;
            this.Species = species;
            this.Vaccinations = vaccinations;
        }



        public List<string> vaccinations = new List<string>();

        public string ListVaccinations()
        {

            string str = String.Join(", ", vaccinations);
            return str;

        }


    }

}
