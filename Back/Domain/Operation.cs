using System;

namespace Domain
{
    public class Operation
    {
        public int Id { get; set; }
        public int Key { get; set; }
        public DateTime? Date { get; set; }
        public float Value { get; set; }
        public string Description { get; set; }
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }
    }
}