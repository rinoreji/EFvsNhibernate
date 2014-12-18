using System;
using System.Collections.Generic;

namespace EFvsNhibernate
{
    public abstract class Party
    {
        public virtual int Id { get; set; }
        public virtual RecordState RecordState { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual Employee CreatedBy { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
        public virtual Employee ModifiedBy { get; set; }
        public virtual string Code { get; set; }
        public virtual IList<Address> Addresses { get; set; }
    }
}
