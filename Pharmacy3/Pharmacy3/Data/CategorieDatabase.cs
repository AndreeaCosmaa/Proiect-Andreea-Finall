using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pharmacy3.Models;
namespace Pharmacy3.Data
{
    public class CategorieDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public CategorieDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Categorie>().Wait();
            _database.CreateTableAsync<CategorieList>().Wait();
            _database.CreateTableAsync<Fabricant>().Wait();
            _database.CreateTableAsync<Medicament>().Wait();
        }
        //CATEGORIE
        public Task<List<Categorie>> GetCategorieAsync()
        {
            return _database.Table<Categorie>().ToListAsync();
        }
      
        public Task<Categorie> GetCategorieAsync(int id)
        {
            return _database.Table<Categorie>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCategorieAsync(Categorie slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteCategorieAsync(Categorie slist)
        {
            return _database.DeleteAsync(slist);
        }
        /*
        public Task<List<Categorie>> GetCategorieAsync(int categorieid)
        {
            return _database.QueryAsync<Categorie>(
            "select C.ID, C.Denumire from Categorie C"
            + " inner join Medicament M"
            + " on C.ID = M.CategorieID where C.Denumire = ?",
            categorieid);
        }*/
        //FABRICANT
        public Task<List<Fabricant>> GetFabricantAsync()
        {
            return _database.Table<Fabricant>().ToListAsync();
        }
        public Task<Fabricant> GetFabricantAsync(int id)
        {
            return _database.Table<Fabricant>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveFabricantAsync(Fabricant slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteFabricantAsync(Fabricant slist)
        {
            return _database.DeleteAsync(slist);
        }
        //MEDICAMENT
        public Task<List<Medicament>> GetMedicamentAsync()
        {
            return _database.Table<Medicament>().ToListAsync();
        }
        public Task<Medicament> GetMedicamentAsync(int id)
        {
            return _database.Table<Medicament>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveMedicamentAsync(Medicament slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteMedicamentAsync(Medicament slist)
        {
            return _database.DeleteAsync(slist);
        }
        //PRODUCT
        public Task<int> SaveListProductAsync(CategorieList listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Categorie>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Categorie>(
            "select C.ID, C.Denumire from Categorie C"
            + " inner join CategorieList CL"
            + " on C.ID = CL.CategorieID where CL.MedicamentID = ?",
            shoplistid);
        }
        public Task<List<Categorie>> DeleteListItemProductsAsync(string shoplistdenumire)
        {
            return _database.QueryAsync<Categorie>(
                "delete from Categorie where Denumire=?", shoplistdenumire);
        }
    }
}

