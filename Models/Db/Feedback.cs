using System;

namespace MVCStartApp.Models.Db
{
    public class Feedback
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string From { get; set; }

    }
}
