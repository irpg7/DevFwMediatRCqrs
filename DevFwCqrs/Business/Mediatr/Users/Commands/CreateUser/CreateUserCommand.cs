using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Mediatr.Users.Commands.CreateUser
{
    public class CreateUserCommand:IRequest<IResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult>
        {
            IUserDal _userDal;
            IMapper _mapper;
            public CreateUserCommandHandler(IUserDal userDal,IMapper mapper)
            {
                _userDal = userDal;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var userExits = await _userDal.GetAsync(u => u.UserName == request.UserName);

                if (userExits != null)
                    return new ErrorResult(Messages.UserExists);

                var user = _mapper.Map<User>(request);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordSalt, out passwordHash);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Status = true;

                await _userDal.AddAsync(user);

                return new SuccessResult(Messages.UserCreated);
            }
        }
    }
}
