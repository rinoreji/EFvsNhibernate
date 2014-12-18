
namespace EFvsNhibernate
{
    public class GeneralCode
    {
        public virtual int Id { get; set; }
        public virtual RecordState RecordState { get; set; }

        public virtual string Type { get; set; }
        public virtual string Code { get; set; }
        public virtual string Value { get; set; }
        public virtual int Index { get; set; }
    }
}
