﻿using System.ComponentModel.DataAnnotations;

namespace Test_ConsoleApp.DataAccess.Entity
{
    public class User
    {
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Domain { get; set; } = default!;
        public List<TagToUser>? Tags { get; set; }
    }
}
