namespace DevFreela.Api.Models
{
    public class ProjectItemViewModel
    {
        public ProjectItemViewModel(int id, string clientName, string freelancerName, decimal totalCost)
        {
            Id = id;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
        }

        public int Id { get; private set; }
        public string ClientName { get; set; }
        public string FreelancerName { get; set; }
        public decimal TotalCost { get; set; }
    }
}