using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financia.Models
{
    public class Category
    {
        [Key]
        private int CategoriaId { get; set; }

        [Column(TypeName = "nvarchar(50")]
        private string Title { get; set; }

        [Column(TypeName = "nvarchar(50")]
        private string Icon { get; set; }

        [Column(TypeName = "nvarchar(50")]
        private string Type { get; set; }

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
