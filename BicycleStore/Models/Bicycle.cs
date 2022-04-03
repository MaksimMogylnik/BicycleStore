using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleStore.Models
{
    public class Bicycle
    {
        public int BicycleId { get; set; }

        [Required]
        public string BicycleTitle { get; set; }

        public int BicycleWeight { get; set; }

        public string BicycleMaterial { get; set; }

        public string BicycleColor { get; set; }

        public string BicycleWheelDiameter { get; set; }

        public string BicycleAdditionalInfo { get; set; } = "N/A";

        [Required]
        public int BicyclePrice { get; set; }

        public string BicycleImage { get; set; }
    }
}
