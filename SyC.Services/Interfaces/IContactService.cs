using SyC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyC.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateAsync(Contact contact);
        Task DeleteByName(string contactName);
        Task DeleteById(int contactId);
        IEnumerable<Contact> GetAll();
        Task UpdateAsync(Contact contact);
        Task UpdateAsync(int id);
        Contact GetByName(string contactName);
        Contact GetById(int Id);
        IEnumerable<Contact> GetAllById(int contactId);
    }
}
