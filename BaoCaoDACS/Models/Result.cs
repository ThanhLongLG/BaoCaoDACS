using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaoCaoDACS.Models
{
    public class Result
    {
        [Key]
        public int ResultID { get; set; }
        public string Rank { get; set; }

        [ForeignKey("Tournament")]
        public int TournamentID { get; set; }
        public Tournament Tournament { get; set; }

        [ForeignKey("Participant")]
        public int ParticipantID { get; set; }
        public Participant Participant { get; set; }

     
    }
}