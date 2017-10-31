using System;

namespace Citizens
{
    // should we add ICloneable here?
    public interface ICitizen : ICloneable
    {
        string FirstName { get; }
        string LastName { get; }
        Gender Gender { get; }
        DateTime BirthDate { get; }
        string VatId { get; set; }
    }
}