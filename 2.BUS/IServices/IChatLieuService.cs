using _1.DAL.Models;
using _2.BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface IChatLieuService
    {
        string Add(ChatLieuView obj);
        string Update(ChatLieuView obj);
        ChatLieu GetById(Guid id);
        Guid GetIdByName(string input);
        List<ChatLieuView> GetAll();
        
    }
}
