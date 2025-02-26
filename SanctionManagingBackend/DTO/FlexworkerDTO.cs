﻿using Microsoft.Identity.Client;

namespace SanctionManagingBackend.DTO
{
    public class FlexworkerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public bool IsMale { get; set; }
        public DateOnly EmploymentDate { get; set; }
    }
}
