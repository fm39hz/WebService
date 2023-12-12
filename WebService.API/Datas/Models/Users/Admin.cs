using FirebaseAdmin.Auth;
using WebService.API.VirtualBase.Abstract;

namespace WebService.API.Datas.Models.Users;

public record Admin(IUserInfo UserInfo) : UserBase(UserInfo);