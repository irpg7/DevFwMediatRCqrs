using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Mediatr.Users.Queries.LoginUser
{
    public class LoginUserQuery:IRequest<IDataResult<AccessToken>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public class LoginUserQueryHandler:IRequestHandler<LoginUserQuery,IDataResult<AccessToken>>
        {
            IUserDal _userDal;
            ITokenHelper _tokenHelper;

            public LoginUserQueryHandler(IUserDal userDal, ITokenHelper tokenHelper)
            {
                _userDal = userDal;
                _tokenHelper = tokenHelper;
            }

            public async Task<IDataResult<AccessToken>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                var user = await _userDal.GetAsync(u => u.UserName == request.UserName);

                if (user == null)
                    return new ErrorDataResult<AccessToken>(Messages.UserNotFound);

                if (!HashingHelper.VerifyPassword(request.Password, user.PasswordSalt, user.PasswordHash))
                    return new ErrorDataResult<AccessToken>(Messages.WrongPassword);

                var claims = _userDal.GetClaims(user);
                var accessToken = _tokenHelper.CreateAccessToken(user, claims);

                return new SuccessDataResult<AccessToken>(accessToken,Messages.SuccessfulLogin);
            }
        }
    }
}
