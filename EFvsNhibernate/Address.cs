
namespace EFvsNhibernate
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual RecordState RecordState { get; set; }

        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual GeneralCode Country { get; set; }
        public virtual GeneralCode AddressType { get; set; }
    }
}
