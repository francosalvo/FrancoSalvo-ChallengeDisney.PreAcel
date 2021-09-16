using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.PreAcel.Entities
{
    public class User: IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
