using Data.Entities;

namespace Lab_3.Models
{
    public class ContactMapper
    {
        public static ContactEntity ToEntity(Contact model)
        {
            return new ContactEntity()
            {
                ContactId = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Priority = (int)model.Priority,
                Birth = model.Birth,
                Email = model.Email,
                OrganizationId = model.OrganizationId,
            };
        }

        public static Contact ToModel(ContactEntity entity)
        {
            return new Contact()
            {
                Id=entity.ContactId,
                Name = entity.Name,
                Phone = entity.Phone,
                Priority = (Priority)entity.Priority,
                Email = entity.Email,
                OrganizationId = entity.OrganizationId,
            };
        }
    }
}
