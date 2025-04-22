using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaoCaoDACS.Models
{
    public class Participant
    {
        public int ParticipantID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Club { get; set; }
        public decimal Score { get; set; } = 0;

        public ICollection<Result> Results { get; set; } = new List<Result>();
  
    }
}