﻿using System.ComponentModel.DataAnnotations;

namespace Test_ConsoleApp.DataAccess.Entity
{
    public class Tag
    {
        public Guid TagId { get; set; }

        [Required]
        public string Value { get; set; } = default!;

        [Required]
        public string Domain { get; set; } = default!;


        public List<User>? Users { get; set; }
    }
}