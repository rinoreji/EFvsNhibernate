using System;

namespace EFvsNhibernate
{
    public abstract class Person : Party
    {
        public virtual string Name { get; set; }
        public virtual GenderTypes Gender { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
    }
}