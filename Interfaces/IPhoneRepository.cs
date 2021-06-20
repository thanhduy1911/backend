using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models.Phone;

namespace backend.Interfaces
{
    public interface IPhoneRepository
    {
        Task<IEnumerable<PhoneDto>> GetPhones();
        Task<PhoneDto> GetPhoneById(int id);
        Task<PhoneDto> CreatePhone(PhoneFormDto model);
        Task<PhoneDto> UpdatePhone(int id, PhoneFormDto model);
        Task<PhoneDto> DeletePhone(int id);
        Task<List<PhoneDto>> GetPhonesByName(string name);
        Task<List<PhoneDto>> GetPhonesByCategory(int id);
        Task<List<PhoneDto>> GetPhonesByCategoryRelation(int id);
    }
}