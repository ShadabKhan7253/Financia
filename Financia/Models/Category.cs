using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financia.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(50")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(50")]
        public string Icon { get; set; }

        [Column(TypeName = "nvarchar(50")]
        public string Type { get; set; }

        public Category() 
        {
            if(Title == null)
            {
                Title = "";
            }
            if (Icon == null)
            {
                Icon = "";
            }
            if (Type == null)
            {
                Type = "";
            }


        }

    }
}
