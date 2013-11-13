using System;
using Template.Core.Model.Entities;

namespace Template.Core.Repositories.Implementations
{
    class UsersRepository: TemplateContextRepository, IUsersRepository
    {
        public UsersRepository(ITemplateContext context)
            : base(context){}

        void IUsersRepository.Add(User user)
        {
            Context.Users.Add(user);
        }

        User IUsersRepository.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
