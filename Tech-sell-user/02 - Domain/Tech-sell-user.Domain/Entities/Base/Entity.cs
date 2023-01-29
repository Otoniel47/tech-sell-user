using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_sell_user.Domain.Entities.Base
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public string? CreatedUserId { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        public string? UpdatedUserId { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string? DeletedUserId { get; set; }
    }
}