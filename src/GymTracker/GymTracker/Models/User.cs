using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymTracker.Models
{
    public class User
    {
        public User()
        {
            Routines = new List<Routine>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoutineId { get; set; }

        public ICollection<Routine> Routines { get; set; }
    }
}