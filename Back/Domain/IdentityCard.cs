using System;

namespace Domain
{
    public class IdentityCard
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Status { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}