using WebService.API.VirtualBase.Interface;

namespace WebService.API.Datas.Models.Users;

public record Admin(string Id) : UserInformation(Id);