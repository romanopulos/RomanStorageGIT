using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    public enum Sex
    {
        Male,
        Female
    }
    public enum TicketClass
    {
        Business,
        Economy
    }
    public enum TicketCategory
    {
        CategoryA,
        CategoryB,
        CategoryC
    }
    public enum KindOfFlight
    {
        Arrival,
        Departure
    }
    public enum FlightStatus
    {
        CheckIn,
        GateClosed,
        Arrived,
        DepartedAt,
        Unknown,
        Canceled,
        ExpectedAt,
        Delayed
    }

    abstract class CommercialOrganisation
    {
        public string LicenseNumber;
        public bool IsLicenseValid;
        public DateTime DateExpired;
        public abstract void GetLicense();
        public abstract void CancelLicense();

        public CommercialOrganisation(string LicenseNumber, bool IsLicenseValid, DateTime DateExpired)
        {
            this.LicenseNumber = LicenseNumber;
            this.IsLicenseValid = IsLicenseValid;
            this.DateExpired = DateExpired;
        }
    }
}
