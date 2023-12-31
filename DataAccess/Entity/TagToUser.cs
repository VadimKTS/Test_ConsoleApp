﻿using System.ComponentModel.DataAnnotations;

namespace Test_ConsoleApp.DataAccess.Entity
{
    public class TagToUser
    {
        public Guid TagToUserId { get; set; }
        public Guid UserId { get; set; }
        public Guid TagId { get; set; }


        public User? User { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
