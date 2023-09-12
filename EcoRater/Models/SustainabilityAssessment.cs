using System;
using Microsoft.AspNetCore.Identity;

namespace EcoRater.Models
{
	public class SustainabilityAssessment
	{
        public int Id { get; set; } // Primary Key
        public string? Industry { get; set; }
        public string? BusinessNature { get; set; }
        public string? BusinessSize { get; set; }
        public string? OperationalRegions { get; set; }
        public bool? ManufacturingInvolved { get; set; }
        public bool? SourcingFromOutside { get; set; }
        public string? SourcingType { get; set; } // Local or International
        public bool? ImpactOnLandUse { get; set; }
        public int? NumberOfEmployees { get; set; }
        public bool? PreviousSustainabilityInitiatives { get; set; }
        public bool? ProduceEmissionsOrWaste { get; set; }

        // Foreign keys
        public int? ProjectFirmId { get; set; }
        public string? UserId { get; set; }

        // Navigation properties
        public ProjectFirm? ProjectFirm { get; set; }
        public IdentityUser? User { get; set; }
    }
}

