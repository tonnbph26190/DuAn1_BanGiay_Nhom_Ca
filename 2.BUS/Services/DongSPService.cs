using _1.DAL.IRepositories;
using _1.DAL.Models;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class DongSPService: IDongSPService
    {
        private IDongSpRepositories _dongSpRepositories;
        private List<DongSP> _lstDongSp;

        public DongSPService()
        {
            _dongSpRepositories = new DongSpRepositories();
            _lstDongSp = new List<DongSP>();
        }
        public bool Add(DongSP dsp)
        {
            _dongSpRepositories.Add(dsp);
            return true;
        }

        public bool Update(DongSP dsp)
        {
            _dongSpRepositories.Update(dsp);
            return true;
        }

        public List<DongSP> GetAll()
        {
            _lstDongSp = _dongSpRepositories.GetAll();
            return _lstDongSp;
        }

        public DongSP GetById(Guid id)
        {
            return _dongSpRepositories.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdByName(string input)
        {
            return GetAll().FirstOrDefault(c => c.Ten == input).Id;
        }
    }
}
