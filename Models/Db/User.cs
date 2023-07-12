using System;

namespace MVCStartApp.Models.Db
{
    public class User
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
