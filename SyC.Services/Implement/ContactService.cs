using Syc.Persistence;
using SyC.Entity;
using SyC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyC.Services.Implement
{
    public class ContactService : IContactService
    {
        private readonly SycContext _context;
        public ContactService(SycContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }
        public Contact GetById(int contactId)
        {
            return _context.Contacts.Where(e => e.Id == contactId).FirstOrDefault();
        }

        public async Task DeleteById(int contactId)
        {
            var contact = GetById(contactId);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
        public Contact GetByName(string contactName)
        {
            return _context.Contacts.Where(e => e.FirstName == contactName).FirstOrDefault();
        }
        public async Task DeleteByName(string contactName)
        {
            var contact = GetByName(contactName);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
       
        public IEnumerable<Contact> GetAllById(int contactId)
        {
            return _context.Contacts.Where(e => e.UserId == contactId);
        }

        public async Task UpdateAsync(Contact contact)
        {
            _context.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var contact = GetById(id);
            _context.Update(contact);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Contact> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
