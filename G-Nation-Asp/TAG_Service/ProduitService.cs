using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAG_DATA.Models;
using TAG_Domain.Entities;
using TAG_DATA.Infrastructure;

namespace TAG_Service
{
    public class ProduitService : IProduitService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddProduit(produit p)
        {
            utwk.ProduitRepository.Add(p);
            utwk.Commit();
        }

        public void Delete(produit p)
        {
            utwk.ProduitRepository.Delete(p);
            utwk.Commit();

        }

       

        public List<produit> getAllProduits()
        {
            return utwk.ProduitRepository.GetAll().ToList();
        }

        public produit getById(int id)
        {
            return utwk.ProduitRepository.GetById(id);
        }

        public void Update(produit p)
        {
            utwk.ProduitRepository.Update(p);
            utwk.Commit();
        }
        public async Task<List<produit>> FindAllAsync(Expression<Func<produit, bool>> match)
        {
            return await utwk.GetRepository<produit>().FindAllAsync(match);
        }
        public virtual async Task<produit> FindAsync(Expression<Func<produit, bool>> match)
        {
            //return await _repository.FindAsync(match);
            return await utwk.GetRepository<produit>().FindAsync(match);
        }

        public int CountProduit(string idUser)
        {



            var hi = utwk.GetRepository<produit>().GetMany(h => h.idUser.Equals(idUser));
            int nbrhiii = hi.Count();
            return nbrhiii;
        }
    } 
    public interface IProduitService
    {
        void AddProduit(produit p);
        List<produit> getAllProduits();
        produit getById(int id);
        void Delete(produit p);
        void Update(produit p);
        int CountProduit(string idUser);
        Task<produit> FindAsync(Expression<Func<produit, bool>> match);
        Task<List<produit>> FindAllAsync(Expression<Func<produit, bool>> match);
    }
}
