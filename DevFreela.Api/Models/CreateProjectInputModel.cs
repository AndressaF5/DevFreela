using DevFreela.Api.Entities;

namespace DevFreela.Api.Models
{
    public class CreateProjectInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCost { get; set; }

        public Project ToEntity()
        {
            return new(Title, Description, IdClient, IdFreelancer, TotalCost);
        }
    }
}