using ChallengeDisney.PreAcel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.PreAcel.DTO.GET
{
    public class MovieOrSerieDTO
    {

        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime GetDate { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
