using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChallengeDisney.PreAcel.Entities
{
    public class MovieOrSerie
    {
        public int Id { get; set; }
        public string Image { get; set; }   
        public string Title { get; set; }
        public DateTime GetDate { get; set; }

        [Range(1,5)]
        public int Score { get; set; }

        public Gender Gender { get; set; }
        public ICollection<Character> Characters { get; set; }

        
    }
}
