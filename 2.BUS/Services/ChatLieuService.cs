using _1.DAL.IRepositories;
using _1.DAL.Models;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class ChatLieuService: IChatLieuService
    {
        private IChatLieuRepositories _iChatLieuRepository;
        public ChatLieuService()
        {
            _iChatLieuRepository = new ChatLieuRepositories();
        }

        public string Add(ChatLieuView obj)
        {
            if (obj == null) return "thêm thất bại";
            var size = new ChatLieu()
            {
                Ma = obj.Ma,
                Ten = obj.Ten,
                TrangThai = obj.TrangThai,
            };
            if (_iChatLieuRepository.Add(size)) return "thêm thành công";
            return "thêm thất bại";
        }

        public string Update(ChatLieuView obj)
        {
            if (obj == null) return "sửa thất bại";
            var size = _iChatLieuRepository.GetAll().FirstOrDefault(c => c.Id== obj.Id);
            size.Ten = obj.Ten;
            size.Ma = obj.Ma;
            size.TrangThai = obj.TrangThai;
            if (_iChatLieuRepository.Update(size)) return "sửa thành công";
            return "sửa thất bại";
        }

        

        public List<ChatLieuView> GetAll()
        {
            List<ChatLieuView> lst = new List<ChatLieuView>();
            lst =
                (
                    from a in _iChatLieuRepository.GetAll()
                    select new ChatLieuView()
                    {
                        Id = a.Id,
                        Ma = a.Ma,
                        Ten = a.Ten,
                        TrangThai = a.TrangThai,
                    }
                ).ToList();
            return lst;
        }
        public ChatLieu GetById(Guid id)
        {
            return _iChatLieuRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public Guid GetIdByName(string input)
        {
            return GetAll().FirstOrDefault(c => c.Ten == input).Id;
        }
    }
}
