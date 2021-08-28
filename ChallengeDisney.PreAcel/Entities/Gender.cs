using System.Collections.Generic;


namespace ChallengeDisney.PreAcel.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<MovieOrSerie> MovieOrSeries { get; set; }


    }
}
