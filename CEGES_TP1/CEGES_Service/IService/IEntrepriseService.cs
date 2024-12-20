using CEGES_Models.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;
using CEGES_Models;
using CEGES_MVC.Models;
using CEGES_Core.ViewModels;

namespace CEGES_Service.IService
{
    public interface IEntrepriseService
    {

 
        public Task<List<ListeEntreprisesVM>> GetEntreprisesAndCountsAsync();

        public Task<DetailEntrepriseVM> GetEntrepriseDetailAsync(int id);
        public Task<Entreprise> GetEntrepriseAsync(int id);
        public Task AddEntrepriseAsync(Entreprise entreprise);
        public void UpdateEntreprise(Entreprise entreprise);
       // public Task<Groupe> GetGroupeDetailsAsync(int id);
        //public Task<Equipement> GetEquipementDetailAsync(int id);
        //public Task<Groupe> GetGroupeAsync(int id);
        //public Task<Equipement> NewEquipementAsync(int id, string type);
        //public Task AddEquipementAsync(Equipement equipement);
        //public Task<Groupe> NewGroupeAsync(int entrepriseId);
        //public void UpdateEquipement(Equipement equipement);
        //public Task<Groupe> GetGroupeEtEntrepriseAsync(int id);
        //public Task AddGroupeAsync(Groupe groupe);
       // public void UpdateGroupe(Groupe groupe);
       // public Task EditAnalystesEntrepriseAsync(int entrepriseId, List<string> analysteIds);
        public IEntrepriseService Configuration { get; }


    }
}
