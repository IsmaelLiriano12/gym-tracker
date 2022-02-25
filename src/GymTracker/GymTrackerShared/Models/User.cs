using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymTrackerShared.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoutineId { get; set; }

        public Routine Routine { get; set; }
    }
}