using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Entities;
using backend.Interfaces;
using backend.Models.Phone;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.PhoneRepository
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PhoneRepository(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<PhoneDto> CreatePhone(PhoneFormDto model)
        {
            var phone = new Phone
            {
                PhoneName = model.PhoneName,
                PhoneImage = model.PhoneImage,
                PhoneDescription = model.PhoneDescription,
                PhonePrice = model.PhonePrice,
                PhoneQuantity = model.Quantity,
                ShortDescription = model.ShortDescription,
                CategoryId = model.CategoryId,
                CreateDate = model.CreateDate

            };
            _dbContext.Phones.Add(phone);
            await _dbContext.SaveChangesAsync();

            var phoneDuplicate = new PhoneDto
            {
                PhoneId = phone.PhoneId,
                PhoneImage = phone.PhoneImage,
                PhoneName = phone.PhoneName,
                PhonePrice = phone.PhonePrice,
                PhoneDescription = phone.PhoneDescription,
                PhoneQuantity = phone.PhoneQuantity,
                ShortDescription = phone.ShortDescription,
                CategoryId = phone.CategoryId,
                CreateDate = phone.CreateDate
            };
            return phoneDuplicate;
        }

        public async Task<PhoneDto> DeletePhone(int id)
        {
            var phone = await _dbContext.Phones.FirstOrDefaultAsync(x => x.PhoneId == id);
            if (phone == null)
            {
                throw new System.Exception("Not found");
            }
            _dbContext.Phones.Remove(phone);
            await _dbContext.SaveChangesAsync();

            var phones = new PhoneDto
            {
                PhoneId = phone.PhoneId,
                PhoneName = phone.PhoneName,
                PhoneDescription = phone.PhoneDescription,
                ShortDescription = phone.ShortDescription,
                PhonePrice = phone.PhonePrice,
                PhoneImage = phone.PhoneImage,
                PhoneQuantity = phone.PhoneQuantity,
                CategoryId = phone.CategoryId
            };
            return phones;
        }

        public async Task<PhoneDto> GetPhoneById(int id)
        {
            var phones = await _dbContext.Phones.FindAsync(id);
            if (phones == null)
            {
                throw new System.Exception("Not found");
            }
            var phone = new PhoneDto
            {
                PhoneId = phones.PhoneId,
                PhoneName = phones.PhoneName,
                PhoneImage = phones.PhoneImage,
                PhoneDescription = phones.PhoneDescription,
                PhonePrice = phones.PhonePrice,
                PhoneQuantity = phones.PhoneQuantity,
                ShortDescription = phones.ShortDescription,
                CategoryId = phones.CategoryId,
                CreateDate = phones.CreateDate
            };
            return phone;
        }

        public async Task<IEnumerable<PhoneDto>> GetPhones()
        {
            return await _dbContext.Phones.Select(phone => new PhoneDto
            {
                PhoneId = phone.PhoneId,
                PhoneName = phone.PhoneName,
                PhoneImage = phone.PhoneImage,
                PhoneDescription = phone.PhoneDescription,
                PhonePrice = phone.PhonePrice,
                PhoneQuantity = phone.PhoneQuantity,
                ShortDescription = phone.ShortDescription,
                CategoryId = phone.CategoryId,
                CreateDate = phone.CreateDate
            }).ToListAsync();
        }

        public async Task<List<PhoneDto>> GetPhonesByCategory(int id)
        {
            var phones = await _dbContext.Phones.Where(x => x.CategoryId == id).ToListAsync();
            List<PhoneDto> phoneListVm = new();
            foreach (var product in phones)
            {
                PhoneDto productVm = new()
                {
                    CategoryId = product.CategoryId,
                    PhoneId = product.PhoneId,
                    PhoneName = product.PhoneName,
                    PhoneDescription = product.PhoneDescription,
                    ShortDescription = product.ShortDescription,
                    PhonePrice = product.PhonePrice,
                    PhoneImage = product.PhoneImage,
                    PhoneQuantity = product.PhoneQuantity,
                    CreateDate = product.CreateDate,
                };
                phoneListVm.Add(productVm);
            }
            return phoneListVm;
        }

        public async Task<List<PhoneDto>> GetPhonesByCategoryRelation(int id)
        {
            var phones = await _dbContext.Phones.FirstOrDefaultAsync(x => x.PhoneId == id);
            var phones1 = await _dbContext.Phones.Where(x => x.PhoneId != id && x.CategoryId == phones.CategoryId)
                .ToListAsync();
            List<PhoneDto> phoneListVm = new();
            foreach (var product in phones1)
            {
                PhoneDto productVm = new()
                {
                    CategoryId = product.CategoryId,
                    PhoneId = product.PhoneId,
                    PhoneName = product.PhoneName,
                    PhoneDescription = product.PhoneDescription,
                    ShortDescription = product.ShortDescription,
                    PhonePrice = product.PhonePrice,
                    PhoneImage = product.PhoneImage,
                    PhoneQuantity = product.PhoneQuantity,
                    CreateDate = product.CreateDate,
                };
                phoneListVm.Add(productVm);
            }
            return phoneListVm;
        }

        public async Task<List<PhoneDto>> GetPhonesByName(string name)
        {
            var phones = await _dbContext.Phones.Where(x => x.PhoneName.Contains(name)).ToListAsync();
            List<PhoneDto> phoneListVm = new();
            foreach (var product in phones)
            {
                PhoneDto productVm = new()
                {
                    CategoryId = product.CategoryId,
                    PhoneId = product.PhoneId,
                    PhoneName = product.PhoneName,
                    PhoneDescription = product.PhoneDescription,
                    ShortDescription = product.ShortDescription,
                    PhonePrice = product.PhonePrice,
                    PhoneImage = product.PhoneImage,
                    PhoneQuantity = product.PhoneQuantity,
                    CreateDate = product.CreateDate,
                };
                phoneListVm.Add(productVm);
            }
            return phoneListVm;
        }

        public async Task<PhoneDto> UpdatePhone(int id, PhoneFormDto model)
        {
            var phone = await _dbContext.Phones.FirstOrDefaultAsync(x => x.PhoneId == id);
            if (phone == null)
            {
                throw new System.Exception("Not found");
            }
            phone.PhoneName = model.PhoneName;
            phone.PhoneDescription = model.PhoneDescription;
            phone.ShortDescription = model.ShortDescription;
            phone.PhonePrice = model.PhonePrice;
            phone.PhoneImage = model.PhoneImage;
            phone.PhoneQuantity = model.Quantity;
            phone.CategoryId = model.CategoryId;

            await _dbContext.SaveChangesAsync();
            var phones = new PhoneDto
            {
                PhoneId = phone.PhoneId,
                PhoneName = phone.PhoneName,
                PhoneDescription = phone.PhoneDescription,
                ShortDescription = phone.ShortDescription,
                PhonePrice = phone.PhonePrice,
                PhoneImage = phone.PhoneImage,
                PhoneQuantity = phone.PhoneQuantity,
                CategoryId = phone.CategoryId
            };
            return phones;
        }
    }
}