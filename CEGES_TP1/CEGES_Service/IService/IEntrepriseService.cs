
using CEGES_Models;



namespace CEGES_Services
{
    public interface IEntrepriseService : IServiceBaseAsync<Entreprise>
    {
        Task AddEntrepriseAsync(Entreprise entreprise);
        Task<IReadOnlyList<Entreprise>> GetAllIndexAsync();
        Task<IReadOnlyList<Entreprise>> GetAllEntreprisesByIdAsync(int id); 
        Task<Entreprise> GetEntrepriseByIdAsync(int id);
        Task EditAsync(Entreprise entreprise);
    }
}
